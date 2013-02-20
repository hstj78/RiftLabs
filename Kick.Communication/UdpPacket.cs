using System;

namespace RiftLabs.Kick.Communication
{
	public class UdpPacket
	{
    public byte[] Address { get; set; }
    public byte Command { get; set; }
		public byte[] Data { get; set; }

		public UdpPacket(byte[] address, byte command, byte[] data)
		{
      Address = address;
      Command = command;
			Data = data;
		}
	}	
}
