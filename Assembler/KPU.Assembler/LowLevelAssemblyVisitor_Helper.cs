using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPU_Assembler
{
    public partial class LowLevelAssemblyVisitor<Result>
    {
        public string GetRegisterOpCode_ALU(string Register)
        {
            switch (Register)
            {
                case "A": return "0";
                case "B": return "1";
            }

            throw new Exception("Invalid Register for MOV_ALU_IN!");
        }

        private static string GetRegisterOpCode_GeneralPurpose(string Register)
        {
            switch (Register)
            {
                case "D": return "000";
                case "E": return "001";
                case "F": return "010";
                case "G": return "011";
                case "H": return "100";
                // case "MH": return "101";
                case "XL": return "110";
                case "XH": return "111";
            }

            throw new Exception("Invalid Register for MOV/LOAD/STORE!");
        }

        private static string GetRegisterOpCode_GeneralPurpose_MOV16(string Register)
        {
            switch (Register)
            {
                case "M": return "000";
                case "X": return "001";
                case "J": return "010";
                case "SP": return "011";
                case "PC": return "100";
                case "BP": return "101";
                case "Y": return "110";
                case "Z": return "111";
            }

            throw new Exception("Invalid Register for MOV16!");
        }
    }
}
