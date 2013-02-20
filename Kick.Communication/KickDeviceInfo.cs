using System;

namespace RiftLabs.Kick.Communication
{
	public class KickDeviceInfo
	{
		public string Name { get; set; }

		public byte[] Address { get; set; }

		public sbyte? EmitterTemperature { get; set; }

		public byte? Power { get; set; }

		public bool IsCharging { get { return Power == byte.MaxValue; } }

		public int? EV { get; set; }

		public Version FirmwareVersion { get; set; }

		public Version HardwareVersion { get; set; }

		public string SerialNumber { get; set; }

    public RGBColor? Color { get; set; }

    public override string ToString()
    {
      return (string.IsNullOrEmpty(Name) ? "N/A" : Name) + " (Address: " + Communicator.ToHexString(Address) + ")";
    }
	}
}