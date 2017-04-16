using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPU.Emulation
{
    public class Register16
    {
        private BitArray _value;

        public BitArray Value
        {
            get { return _value; }
        }

        public Register16()
        {
            _value = new BitArray(16);
        }

        public void SetBit(int Position, bool Value)
        {
            _value[Position] = Value;
        }

        public void SetBits(int Value)
        {
            string bits = Helper.IntToBinary(Value, 16);

            _value[15] = bits.Substring(0, 1) == "1";
            _value[14] = bits.Substring(1, 1) == "1";
            _value[13] = bits.Substring(2, 1) == "1";
            _value[12] = bits.Substring(3, 1) == "1";
            _value[11] = bits.Substring(4, 1) == "1";
            _value[10] = bits.Substring(5, 1) == "1";
            _value[9] = bits.Substring(6, 1) == "1";
            _value[8] = bits.Substring(7, 1) == "1";
            _value[7] = bits.Substring(8, 1) == "1";
            _value[6] = bits.Substring(9, 1) == "1";
            _value[5] = bits.Substring(10, 1) == "1";
            _value[4] = bits.Substring(11, 1) == "1";
            _value[3] = bits.Substring(12, 1) == "1";
            _value[2] = bits.Substring(13, 1) == "1";
            _value[1] = bits.Substring(14, 1) == "1";
            _value[0] = bits.Substring(15, 1) == "1";
        }

        /// <summary>
        /// Returns the String value of the register.
        /// </summary>
        /// <returns></returns>
        public string GetString()
        {
            StringBuilder builder = new StringBuilder();
            
            if (_value[15] == true) builder.Append("1"); else builder.Append("0");
            if (_value[14] == true) builder.Append("1"); else builder.Append("0");
            if (_value[13] == true) builder.Append("1"); else builder.Append("0");
            if (_value[12] == true) builder.Append("1"); else builder.Append("0");
            if (_value[11] == true) builder.Append("1"); else builder.Append("0");
            if (_value[10] == true) builder.Append("1"); else builder.Append("0");
            if (_value[9] == true) builder.Append("1"); else builder.Append("0");
            if (_value[8] == true) builder.Append("1"); else builder.Append("0");
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
        public int GetInt()
        {
            int[] array = new int[1];
            _value.CopyTo(array, 0);
            return array[0];
        }

        /// <summary>
        /// Increments the value of the Register by 1.
        /// </summary>
        public void Increment()
        {
            int i = GetInt();
            i++;
            SetBits(i);
        }
    }
}