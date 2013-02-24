using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using RiftLabs.Kick.Communication;
using RiftLabs.Kick.Utils;

namespace RiftLabs.Kick.UI
{
  public partial class Form1 : Form
  {
    private Communicator m_Controller;

    public Form1()
    {
      InitializeComponent();
      m_Controller = new Communicator() { TransmitInterval = Convert.ToInt32(responseDelay.Value) };
      m_Controller.OnDebugMessage += OnDebugMessage;
      m_Controller.OnKickDeviceChanged += OnKickDeviceChanged;
      m_Controller.OnNewKickDevice += OnNewKickDevice;
      cboDevices.DataSource = AllDevices;
      cboDevices.SelectedIndex = 0;
    }

    private IEnumerable<KickDeviceInfo> AllDevices
    {
      get
      {
        return new[] { new KickDeviceInfo { Name = "(All)", Address = Address.All } }.Concat(m_Controller.KickDevices).ToArray();
      }
    }

    private KickDeviceInfo ActiveDevice
    {
      get
      {
        var device = AllDevices.ElementAt(cboDevices.SelectedIndex);
        return device != null ? device : AllDevices.First();
      }
    }

    private void OnNewKickDevice(KickDeviceInfo device)
    {
      BeginInvoke(new Action(() =>
      {
        var devices = AllDevices.ToArray();
        cboDevices.DataSource = devices;
        cboDevices.SelectedIndex = devices.Count() - 1;
      }));
    }

    private void OnKickDeviceChanged(KickDeviceInfo device)
    {
      BeginInvoke(new Action(() =>
      {
        var index = cboDevices.SelectedIndex;
        cboDevices.DataSource = AllDevices.ToArray();
        cboDevices.SelectedIndex = index;

        if (ActiveDevice == device)
          UpdateUI();
      }));
    }

    private void OnDebugMessage(string message)
    {
      BeginInvoke(new Action(() => txtLog.Text = message + "\r\n" + txtLog.Text));
    }

    private void Form1_Load(object sender, EventArgs e)
    {
      UpdateUI();
      txtLog.Text = "Welcome.";
    }

    private void Form1_Shown(object sender, EventArgs e)
    {
      txtLog.Select(0, 0);
      btnConnect.Focus();
    }

    private void UpdateUI()
    {
      btnConnect.Text = m_Controller.Connected ? "Disconnect" : "Connect";
      btnHello.Enabled = m_Controller.Connected;
      btnCustom.Enabled = m_Controller.Connected;
      btnEV2.Enabled = m_Controller.Connected;
      btnHello.Enabled = m_Controller.Connected;
      btnRGB.Enabled = m_Controller.Connected;
      btnVersion.Enabled = m_Controller.Connected;
      btnStatus.Enabled = m_Controller.Connected;
      var selectedDevice = cboDevices.SelectedValue as KickDeviceInfo;
      
      if (selectedDevice.Address == Address.All)
      {
        grpKickInfo.Enabled = false;
        lblAddress.Text = "Address: N/A";
        lblEV2Level.Text = "EV2 level: N/A";
        lblName.Text = "Name: N/A";
        lblPower.Text = "Power: N/A";
        lblFWVersion.Text = "Firmware version: N/A";
        lblHWVersion.Text = "Hardware version: N/A";
        lblSerialNumber.Text = "Serial number: N/A";
        lblTemperature.Text = "Temperature °C: N/A";
        pnlRGBId.BackColor = Color.Transparent;
      }
      else
      {
        grpKickInfo.Enabled = true;
        lblAddress.Text = "Address: " + selectedDevice.Address.ToHexString();
        lblEV2Level.Text = "EV2 level: " + (selectedDevice.EV.HasValue ? selectedDevice.EV.Value.ToString() : "?");
        lblName.Text = "Name: " + (selectedDevice.Name != null ? selectedDevice.Name : "?");
        lblPower.Text = "Power: " + PowerAsString(selectedDevice.Power);
        lblFWVersion.Text = "Firmware version: " + (selectedDevice.FirmwareVersion != null ? selectedDevice.FirmwareVersion.ToString() : "?");
        lblHWVersion.Text = "Hardware version: " + (selectedDevice.HardwareVersion != null ? selectedDevice.HardwareVersion.ToString() : "?");
        lblSerialNumber.Text = "Serial number: " + (selectedDevice.SerialNumber != null ? selectedDevice.SerialNumber : "?");
        lblTemperature.Text = "Temperature °C: " + (selectedDevice.EmitterTemperature.HasValue ? selectedDevice.EmitterTemperature.Value.ToString() : "?");
        pnlRGBId.BackColor = ToColor(selectedDevice.Color);
      }
    }

    private Color ToColor(RGBColor? color)
    {
      if (!color.HasValue)
        return Color.Transparent;
      else
        return Color.FromArgb(color.Value.Red, color.Value.Green, color.Value.Blue);
    }

    private string PowerAsString(byte? power)
    {
      if (!power.HasValue)
        return "?";
      else if (power.Value == byte.MaxValue)
        return "(Charging)";
      else
        return power.Value.ToString();
    }

    private void btnConnect_Click(object sender, EventArgs e)
    {
      if (!m_Controller.Connected)
      {
        cboDevices.DataSource = AllDevices;
      }

      if (!m_Controller.Connected)
        m_Controller.Connect();
      else
        m_Controller.Disconnect();

      UpdateUI();
    }

    private void btnHello_Click(object sender, EventArgs e)
    {
      m_Controller.RegisterUdpPacketToSend(new UdpPacket(ActiveDevice.Address, 0x80, null));
    }

    private void btnVersion_Click(object sender, EventArgs e)
    {
      m_Controller.RegisterUdpPacketToSend(new UdpPacket(ActiveDevice.Address, 0x87, null));
    }

    private void btnCustom_Click(object sender, EventArgs e)
    {
      var data = txtHex.Text.Replace(" ", "").FromHexString();
      m_Controller.RegisterUdpPacketToSend(new UdpPacket(ActiveDevice.Address, data[0], data.Length > 1 ? data.Skip(1).ToArray() : null));
    }

    private void btnStatus_Click(object sender, EventArgs e)
    {
      m_Controller.RegisterUdpPacketToSend(new UdpPacket(ActiveDevice.Address, 0x83, null));
    }

    private void pnlRGB_Click(object sender, EventArgs e)
    {
      if (colorDialogRGB.ShowDialog() == System.Windows.Forms.DialogResult.OK)
        pnlRGB.BackColor = colorDialogRGB.Color;
    }

    private void EV2Slider_Scroll(object sender, EventArgs e)
    {
      btnEV2.Text = "EV2: " + EV2Slider.Value;
    }

    private void btnRGB_Click(object sender, EventArgs e)
    {
      m_Controller.RegisterUdpPacketToSend(new UdpPacket(ActiveDevice.Address, 0x01, new byte[] { pnlRGB.BackColor.R, pnlRGB.BackColor.G, pnlRGB.BackColor.B }));
    }

    private void btnEV2_Click(object sender, EventArgs e)
    {
      m_Controller.RegisterUdpPacketToSend(new UdpPacket(ActiveDevice.Address, 0x06, new byte[] { Convert.ToByte(EV2Slider.Value) }));
    }

    private void cboDevices_SelectedValueChanged(object sender, EventArgs e)
    {
      UpdateUI();
    }

    private void btnSummary_Click(object sender, EventArgs e)
    {
      m_Controller.RegisterUdpPacketToSend(new UdpPacket(ActiveDevice.Address, 0x91, null));
    }
  }
}
