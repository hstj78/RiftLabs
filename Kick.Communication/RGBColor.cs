using System;
using System.IO;

namespace RiftLabs.Kick.Communication
{
	public struct RGBColor
	{
		public ushort Time;
		public byte Red;
		public byte Green;
		public byte Blue;

		public RGBColor(byte red, byte green, byte blue) : this(0, red, green, blue)
		{
		}

		public RGBColor(DateTime start, byte red, byte green, byte blue) : this(0, red, green, blue)
		{
			this.Time = Convert.ToUInt16(DateTime.Now.Subtract(start).TotalMilliseconds);
		}

		public RGBColor(ushort time, byte red, byte green, byte blue)
		{
			this.Time = time;
			this.Red = red;
			this.Green = green;
			this.Blue = blue;
		}

		public RGBColor(BinaryReader reader)
		{
			this.Time = reader.ReadUInt16();
			this.Red = reader.ReadByte();
			this.Green = reader.ReadByte();
			this.Blue = reader.ReadByte();
		}

		public void Write(BinaryWriter writer)
		{
			writer.Write(Time);
			writer.Write(Red);
			writer.Write(Green);
			writer.Write(Blue);
		}

		public byte[] ToBytes()
		{
			return new[] { Red, Green, Blue };
		}
	}
}