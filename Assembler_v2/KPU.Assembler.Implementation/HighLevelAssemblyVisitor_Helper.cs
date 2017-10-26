using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPU_Assembler
{
    public partial class HighLevelAssemblyVisitor<Result>
    {
        /// <summary>
        /// Converts the provided integer value to a 8-bit binary value.
        /// </summary>
        /// <param name="IntValue"></param>
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

        /// <summary>
        /// Converts the provided hex value to a 8-bit binary value.
        /// </summary>
        /// <param name="HexValue"></param>
        /// <returns></returns>
        public string HexToBinary(string HexValue)
        {
            return String.Join(String.Empty, HexValue.Select(c => Convert.ToString(Convert.ToInt32(c.ToString(), 16), 2).PadLeft(4, '0')));
        }

        /// <summary>
        /// Generates the necessary opcodes for the MOV8 instruction.
        /// </summary>
        /// <param name="Line"></param>
        /// <returns></returns>
        public List<string> GenerateMnemonics_MOV8(string Line)
        {
            List<string> mnemonics = new List<string>();

            // Index 0: "MOV8"
            // Index 1: "D, "
            // Index 2: "bbbbbbbb"
            string[] parts = Line.Split(' ');
            parts[0].Trim();
            parts[1] = parts[1].Trim().Substring(0, parts[1].Length - 1);
            parts[2] = parts[2].Trim().Substring(1, parts[2].Length - 2);
            string highNibble = parts[2].Substring(0, 4);
            string lowNibble2 = parts[2].Substring(4, 4);

            // mnemonics.Add("SET A, \"" + nibble1 + "\"");
            // mnemonics.Add("SET B, \"" + nibble2 + "\"");
            mnemonics.Add("SET A, \"" + lowNibble2 + "\"");
            mnemonics.Add("SET B, \"" + highNibble + "\"");
            mnemonics.Add("MOV8");
            mnemonics.Add("MOV_ALU_OUT " + parts[1]);

            return mnemonics;
        }

        /// <summary>
        /// Generates the necessary opcodes for the ALU instruction.
        /// </summary>
        /// <param name="line"></param>
        /// <param name="aluOperation"></param>
        /// <returns></returns>
        public static List<string> GenerateMnemonics_ALU(string line, string aluOperation)
        {
            List<string> mnemonics = new List<string>();

            // Index 0: "ADD"
            // Index 1: "D, " // Destination Register
            // Index 2: "E"   // Source Register
            string[] parts = line.Split(' ');
            parts[0].Trim();
            parts[1] = parts[1].Trim().Substring(0, parts[1].Length - 1);
            parts[2].Trim();

            // Emit the correct ALU operation
            mnemonics.Add("MOV_ALU_IN A, " + parts[1]);
            mnemonics.Add("MOV_ALU_IN B, " + parts[2]);
            mnemonics.Add(aluOperation);
            mnemonics.Add("MOV_ALU_OUT " + parts[1]);

            return mnemonics;
        }

        /// <summary>
        /// Generates the necessary opcodes for the ALU instruction.
        /// </summary>
        /// <param name="line"></param>
        /// <param name="aluOperation"></param>
        /// <returns></returns>
        public static List<string> GenerateMnemonics_ALU_OneOperant(string line, string aluOperation)
        {
            List<string> mnemonics = new List<string>();

            // Index 0: "SHL "
            // Index 1: "D" // Source Register
            string[] parts = line.Split(' ');
            parts[0].Trim();
            parts[1].Trim();

            // Emit the correct ALU operation
            mnemonics.Add("MOV_ALU_IN A, " + parts[1]);
            mnemonics.Add(aluOperation);
            mnemonics.Add("MOV_ALU_OUT " + parts[1]);

            return mnemonics;
        }
    }
}
