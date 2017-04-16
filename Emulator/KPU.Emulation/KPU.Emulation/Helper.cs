using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPU.Emulation
{
    public static class Helper
    {
        /// <summary>
        /// Tests if a specific bit is set.
        /// </summary>
        /// <param name="b"></param>
        /// <param name="pos"></param>
        /// <returns></returns>
        public static bool IsBitSet(byte b, int pos)
        {
            return (b & (1 << pos)) != 0;
        }

        /// <summary>
        /// Converts the provided byte value to a 8-bit binary value.
        /// </summary>
        /// <param name="IntValue"></param>
        public static string ByteToBinary(byte ByteValue, int Size)
        {
            BitArray b = new BitArray(new byte[] { ByteValue });
            int[] bits = b.Cast<bool>().Select(bit => bit ? 1 : 0).ToArray();
            string bitValue = string.Empty;
            int i = 0;

            foreach (int bit in bits)
            {
                if (i == Size)
                    break;

                bitValue += bit;
                i++;
            }

            return new string(bitValue.Reverse().ToArray());
        }

        public static string IntToBinary(int IntValue, int Size)
        {
            BitArray b = new BitArray(new int[] { IntValue });
            int[] bits = b.Cast<bool>().Select(bit => bit ? 1 : 0).ToArray();
            string bitValue = string.Empty;
            int i = 0;

            foreach (int bit in bits)
            {
                if (i == Size)
                    break;

                bitValue += bit;
                i++;
            }

            return new string(bitValue.Reverse().ToArray());
        }

        public static byte GetByte(string input)
        {
            List<byte> byteList = new List<byte>();
            for (int i = input.Length - 1; i >= 0; i -= 8)
            {
                string byteString = "";
                for (int j = 0; (i - j) >= 0 && j < 8; j++)
                {
                    byteString = input[i - j] + byteString;
                }
                if (byteString != "")
                {
                    byteList.Add(Convert.ToByte(byteString, 2));
                }
            }

            return byteList.ToArray()[0];
        }
    }
}
