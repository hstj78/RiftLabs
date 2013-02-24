using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using RiftLabs.Kick.Utils;

namespace RiftLabs.Kick.Communication
{
  public class Communicator
  {    
    private List<KickDeviceInfo> m_Devices = new List<KickDeviceInfo>();
    private bool m_Connected = false;
    private bool m_Transmitting = false;
    private UdpPacket m_SendPacket = null;
    private Thread m_ReceiveThread = null;
    private Thread m_SendThread = null;
    private UdpClient m_UdpClient = null;
    private object m_SetSendPacketLock = new object();
    private IPAddress m_Broadcast = null;
    private ReaderWriterLockSlim m_ReaderWriterLock = new ReaderWriterLockSlim();
    private ManualResetEventSlim m_DisconnectCommandSentEvent = new ManualResetEventSlim(false);

    public event Action<KickDeviceInfo> OnNewKickDevice;
    public event Action<KickDeviceInfo> OnKickDeviceChanged;
    public event Action<string> OnDebugMessage;

    public bool Connected { get { return m_Connected; } }

    public int TransmitInterval { get; set; }
    
    public Communicator()
    {
      TransmitInterval = 5;
    }

    public KickDeviceInfo[] KickDevices
    {
      get
      {
        lock (m_Devices)
					return m_Devices.ToArray();
      }
    }

    public KickDeviceInfo GetKickFromAddress(byte[] address)
    {
      if (address == null) throw new ArgumentNullException("address");
      return m_Devices.FirstOrDefault(d => d.Address.SequenceEqual(address));
    }

    public void Connect()
    {
      try
      {
        if (m_UdpClient == null)
        {
          m_DisconnectCommandSentEvent.Reset();
          m_Broadcast = IPAddress.Parse("169.254.255.255");
          DebugWriteLine("Opening connection...");
          m_Devices = new List<KickDeviceInfo>();
          m_UdpClient = new UdpClient();
          m_UdpClient.Client.SendTimeout = 100;
          m_UdpClient.Client.ReceiveTimeout = 100;
          m_UdpClient.EnableBroadcast = true;
          var broadcastAddress = new IPEndPoint(IPAddress.Any, 8080);
          m_UdpClient.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
          m_UdpClient.Client.Bind(broadcastAddress);
          m_Connected = true;
          DebugWriteLine("Connection up!");
          m_Transmitting = true;
          m_SendThread = new Thread(DataBroadcastRunner);
          m_SendThread.IsBackground = false;
          m_SendThread.Start();
          m_ReceiveThread = new Thread(DataReceiveRunner);
          m_ReceiveThread.IsBackground = false;
          m_ReceiveThread.Start();
        }
      }
      catch (Exception err)
      {
        DebugWriteLine("ERR> Connect: " + err.Message);
      }
    }

    public void Disconnect()
    {
      try
      {
        if (m_UdpClient != null && Connected)
        {
          DebugWriteLine("Closing connection...");
          m_DisconnectCommandSentEvent.Reset();
          RegisterUdpPacketToSend(new UdpPacket(Address.All, 0x88, null));
          if (!m_DisconnectCommandSentEvent.Wait(1000))
            DebugWriteLine("WARN> Disconnect timed out!");

          m_ReaderWriterLock.EnterWriteLock();

          try
          {
            m_Transmitting = false;
            m_Connected = false;
            Thread.Sleep(500);
            m_UdpClient.Close();
            m_UdpClient = null;
            DebugWriteLine("Connection closed!");
          }
          finally
          {
            m_ReaderWriterLock.ExitWriteLock();
          }
        }
      }
      catch (Exception err)
      {
        DebugWriteLine("ERR> Disconnect: " + err.Message);
      }
    }

    private void DataBroadcastRunner()
    {      
      while (m_UdpClient != null && m_Connected)
      {
        if (!m_ReaderWriterLock.TryEnterReadLock(100))
          continue;

        try
        {
          if (m_SendPacket == null)
          {
            Thread.Sleep(TransmitInterval);
            continue;
          }

          UdpPacket packet = null;

          lock (m_SetSendPacketLock)
          {
            if (m_SendPacket != null)
            {
              packet = m_SendPacket;
              m_SendPacket = null;
            }
          }

          if (packet != null)
          {            
              Thread.Sleep(TransmitInterval);
              DataBroadcast(packet);
          }
        }
        catch (Exception e)
        {
          DebugWriteLine("ERR> TransmitData: " + e.Message);
        }
        finally
        {
          m_ReaderWriterLock.ExitReadLock();
        }
      }
    }

    private void DataReceiveRunner()
    {
      while (m_Connected && m_UdpClient != null)
      {
        if (!m_ReaderWriterLock.TryEnterReadLock(100))
          continue;

        try
        {
          //Format: <marker><address><length><command><data>
          IPEndPoint endpoint = null;
          byte[] data;
          
          try
          {
            data = m_UdpClient.Receive(ref endpoint);
          }
          catch
          {
            continue;
          }

          if (data == null || data.Length == 0)
            continue;

          var marker = Encoding.ASCII.GetString(data, 0, 2);
          var kickAddress = new byte[] { data[2], data[3], data[4] };

          if (!marker.StartsWith("R"))
            continue;

          // Ignore all non-slave communication
          if (marker != "R$")
            continue;

          var newDevice = false;
					KickDeviceInfo device;
          lock (m_Devices)
          {
            if (!m_Devices.Any(d => d.Address.SequenceEqual(kickAddress)))
            {
              newDevice = true;
							m_Devices.Add(new KickDeviceInfo { Address = kickAddress });              
            }

            device = m_Devices.Single(d => d.Address.SequenceEqual(kickAddress));
          }

					if (newDevice && OnNewKickDevice != null)
						OnNewKickDevice(device);

          var request = new UdpPacket(data.Skip(1).Take(3).ToArray(), data.Skip(7).Take(1).ElementAt(0), data.Length > 8 ? data.Skip(8).ToArray() : null);
          ProcessUdpPacket(device, request);
          DebugWriteLine("IN>  " + data.Take(7).ToHexString() + "   <" + data.Skip(7).Take(1).ToHexString() + "> " + (data.Length > 8 ? data.Skip(8).ToHexString() : ""));
        }
        catch (Exception err)
        {
          DebugWriteLine("ERR> DataReceive: " + err.Message);
        }
        finally
        {
          m_ReaderWriterLock.ExitReadLock();
        }
      }
    }

    private void DataBroadcast(UdpPacket packet)
    {
      try
      {
        if (m_Connected)
        {
          if (packet.Data == null)
            packet.Data = new byte[0];

          var group = packet.Address == Address.All ? byte.MaxValue : byte.MinValue;
          // <marker 16b><address 16b><length 16b><command 8b><data ?b>
          var headerBytes = new byte[] { (byte)'R', (byte)'L', group, packet.Address[0], packet.Address[1], packet.Address[2], 0x00, (byte)(packet.Data.Length + 1), packet.Command };
          var allBytes = new List<byte>(headerBytes);

          if (packet.Data.Length > 0)
            allBytes.AddRange(packet.Data);

          var data = allBytes.ToArray();
          DebugWriteLine("OUT> " + data.Take(8).ToHexString() + " <" + data.Skip(8).Take(1).ToHexString() + "> " +   (data.Length > 9 ? data.Skip(9).ToHexString() : ""));

          m_UdpClient.Send(data, data.Length, new IPEndPoint(m_Broadcast, 8080));

          if (packet.Command == 0x88)
            m_DisconnectCommandSentEvent.Set();
        }
      }
      catch (Exception err)
      {
        DebugWriteLine("ERR> DataBroadcast: " + err.Message);
      }
    }

    private void ProcessUdpPacket(KickDeviceInfo device, UdpPacket request)
    {
      switch (request.Command)
      {
        case 0x01:
          var response = new UdpPacket(Address.All, 0x83, null);
          RegisterUdpPacketToSend(response);
          break;
        case 0x06:
          device.EV = request.Data[0];
          if (OnKickDeviceChanged != null) OnKickDeviceChanged(device);
          break;
        case 0x81:
          var rgbBytes = request.Data.Take(3).ToArray();
          var nameBytes = request.Data.Skip(3).TakeWhile(b => b > 0x0).ToArray();
          device.Name = Encoding.ASCII.GetString(nameBytes);
          device.Color = new RGBColor(rgbBytes[0], rgbBytes[1], rgbBytes[2]);
          if (OnKickDeviceChanged != null) OnKickDeviceChanged(device);
          break;
        case 0x83:
          device.EmitterTemperature = Convert.ToSByte(request.Data[0]);
          device.Power = request.Data[1];
          if (OnKickDeviceChanged != null) OnKickDeviceChanged(device);
          break;
        case 0x87:
          device.FirmwareVersion = new Version(request.Data[0], request.Data[1]);
          device.HardwareVersion = new Version(request.Data[2], request.Data[3]);
          device.SerialNumber = request.Data.Skip(4).Take(4).ToHexString()
            + "-" + request.Data.Skip(8).Take(4).ToHexString()
            + "-" + request.Data.Skip(12).Take(4).ToHexString()
            + "-" + request.Data.Skip(16).Take(4).ToHexString();
          if (OnKickDeviceChanged != null) OnKickDeviceChanged(device);
          break;
        case 0x89:
          device.EmitterTemperature = Convert.ToSByte(request.Data[0]);
          if (OnKickDeviceChanged != null) OnKickDeviceChanged(device);
          break;
        case 0x90:
          device.Power = request.Data[0];
          if (OnKickDeviceChanged != null) OnKickDeviceChanged(device);
          break;
        case 0x91:
          device.EV = request.Data[0];
          device.Color = new RGBColor(request.Data[9], request.Data[10], request.Data[11]);
          device.FirmwareVersion = new Version(request.Data[12], request.Data[13]);
          device.HardwareVersion = new Version(request.Data[14], request.Data[15]);
          device.Name = Encoding.ASCII.GetString(request.Data.Skip(16).TakeWhile(b => b > 0x0).ToArray());
          if (OnKickDeviceChanged != null) OnKickDeviceChanged(device);
          break;
        default:
          break;
      }
    }

    private void DebugWriteLine(string text)
    {
      if (OnDebugMessage != null)
        OnDebugMessage(text);
    }

    public void RegisterUdpPacketToSend(UdpPacket packet)
    {
      if (!m_Transmitting)
        return;

      lock (m_SetSendPacketLock)
      {
        m_SendPacket = packet;
      }
    }
  }
}

