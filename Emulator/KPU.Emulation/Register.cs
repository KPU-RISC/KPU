using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPU.Emulation
{
    public class Register
    {
        private BitArray _value;

        public BitArray Value
        {
            get { return _value; }
        }

        public Register()
        {
            _value = new BitArray(8);
        }

        public void SetBit(int Position, bool Value)
        {
            _value[Position] = Value;
        }

        public void SetBits(byte Value)
        {
            string bits = Helper.ByteToBinary(Value, 8);

            _value[7] = bits.Substring(0, 1) == "1";
            _value[6] = bits.Substring(1, 1) == "1";
            _value[5] = bits.Substring(2, 1) == "1";
            _value[4] = bits.Substring(3, 1) == "1";
            _value[3] = bits.Substring(4, 1) == "1";
            _value[2] = bits.Substring(5, 1) == "1";
            _value[1] = bits.Substring(6, 1) == "1";
            _value[0] = bits.Substring(7, 1) == "1";
        }

        /// <summary>
        /// Returns the String value of the register.
        /// </summary>
        /// <returns></returns>
        public string GetString()
        {
            StringBuilder builder = new StringBuilder();

            if (_value[7] == true) builder.Append("1"); else builder.Append("0");
            if (_value[6] == true) builder.Append("1"); else builder.Append("0");
            if (_value[5] == true) builder.Append("1"); else builder.Append("0");
            if (_value[4] == true) builder.Append("1"); else builder.Append("0");
            if (_value[3] == true) builder.Append("1"); else builder.Append("0");
            if (_value[2] == true) builder.Append("1"); else builder.Append("0");
            if (_value[1] == true) builder.Append("1"); else builder.Append("0");
            if (_value[0] == true) builder.Append("1"); else builder.Append("0");

            return builder.ToString();
        }

        /// <summary>
        /// Returns the Byte value of the register.
        /// </summary>
        /// <returns></returns>
        public byte GetByte()
        {
            byte[] bytes = new byte[1];
            _value.CopyTo(bytes, 0);
            return bytes[0];
        }

        /// <summary>
        /// Returns the Int value of the register.
        /// </summary>
        /// <returns></returns>
        public int GetInt()
        {
            int[] array = new int[1];
            _value.CopyTo(array, 0);
            return array[0];
        }
    }
}