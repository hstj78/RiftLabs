using System.Collections.Generic;
using System.Linq;

namespace RiftLabs.Kick.Utils
{
    public static class StringExtensions
    {
      public static string ToHexString(this IEnumerable<byte> data)
      {
        var dataText = "";
        var count = data.Count();

        for (int i = 0; i < count; i++)
          dataText += data.ElementAt(i).ToString("X2");

        return dataText;
      }

      public static byte[] FromHexString(this string hexString)
      {
        var result = new byte[hexString.Length / 2];
        for (int i = 0; i < hexString.Length / 2; i++)
          result[i] = byte.Parse(hexString.Substring(i * 2, 2), System.Globalization.NumberStyles.HexNumber);

        return result;
      }
    }
}
