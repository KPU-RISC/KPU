using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPU.Emulation
{
    public class InstructionRegister : Register
    {
        public OpCode GetOpCode()
        {
            string opCode = GetString();

            if (opCode.StartsWith("1110"))
                return OpCode.SET_A;
            else if (opCode.StartsWith("1111"))
                return OpCode.SET_B;
            else if (opCode == "10001111")
                return OpCode.MOV8;
            else if (opCode == "10000100")
                return OpCode.ADD;
            else if (opCode == "10000011")
                return OpCode.AND;
            else if (opCode == "10000111")
                return OpCode.ADC;
            else if (opCode == "10001001")
                return OpCode.NEG;
            else if (opCode == "10000000")
                return OpCode.NOP;
            else if (opCode == "10000101")
                return OpCode.NOT;
            else if (opCode == "10000010")
                return OpCode.OR;
            else if (opCode == "10001011")
                return OpCode.RCL;
            else if (opCode == "10001110")
                return OpCode.RCR;
            else if (opCode == "10001101")
                return OpCode.SAR;
            else if (opCode == "10001010")
                return OpCode.SBB;
            else if (opCode == "10000110")
                return OpCode.SHL;
            else if (opCode == "10001100")
                return OpCode.SHR;
            else if (opCode == "10001000")
                return OpCode.SUB;
            else if (opCode == "10000001")
                return OpCode.XOR;

            else if (opCode == "11011000")
                return OpCode.MOV_ALU_OUT_D;
            else if (opCode == "11011001")
                return OpCode.MOV_ALU_OUT_E;
            else if (opCode == "11011010")
                return OpCode.MOV_ALU_OUT_F;
            else if (opCode == "11011011")
                return OpCode.MOV_ALU_OUT_G;
            else if (opCode == "11011100")
                return OpCode.MOV_ALU_OUT_H;
            else if (opCode == "11011110")
                return OpCode.MOV_ALU_OUT_XL;
            else if (opCode == "11011111")
                return OpCode.MOV_ALU_OUT_XH;

            else if (opCode == "10110000")
                return OpCode.MOV_ALU_IN_A_D;
            else if (opCode == "10110001")
                return OpCode.MOV_ALU_IN_A_E;
            else if (opCode == "10110010")
                return OpCode.MOV_ALU_IN_A_F;
            else if (opCode == "10110011")
                return OpCode.MOV_ALU_IN_A_G;
            else if (opCode == "10110100")
                return OpCode.MOV_ALU_IN_A_H;
            else if (opCode == "10110110")
                return OpCode.MOV_ALU_IN_A_XL;
            else if (opCode == "10110111")
                return OpCode.MOV_ALU_IN_A_XH;

            else if (opCode == "10111000")
                return OpCode.MOV_ALU_IN_B_D;
            else if (opCode == "10111001")
                return OpCode.MOV_ALU_IN_B_E;
            else if (opCode == "10111010")
                return OpCode.MOV_ALU_IN_B_F;
            else if (opCode == "10111011")
                return OpCode.MOV_ALU_IN_B_G;
            else if (opCode == "10111100")
                return OpCode.MOV_ALU_IN_B_H;
            else if (opCode == "10111110")
                return OpCode.MOV_ALU_IN_B_XL;
            else if (opCode == "10111111")
                return OpCode.MOV_ALU_IN_B_XH;

            else if (opCode == "00" + GetRegisterOpCode("E") + GetRegisterOpCode("D"))
                return OpCode.MOV_D_TO_E;
            else if (opCode == "00" + GetRegisterOpCode("F") + GetRegisterOpCode("D"))
                return OpCode.MOV_D_TO_F;
            else if (opCode == "00" + GetRegisterOpCode("G") + GetRegisterOpCode("D"))
                return OpCode.MOV_D_TO_G;
            else if (opCode == "00" + GetRegisterOpCode("H") + GetRegisterOpCode("D"))
                return OpCode.MOV_D_TO_H;
            else if (opCode == "00" + GetRegisterOpCode("XL") + GetRegisterOpCode("D"))
                return OpCode.MOV_D_TO_XL;
            else if (opCode == "00" + GetRegisterOpCode("XH") + GetRegisterOpCode("D"))
                return OpCode.MOV_D_TO_XH;

            else if (opCode == "00" + GetRegisterOpCode("D") + GetRegisterOpCode("E"))
                return OpCode.MOV_E_TO_D;
            else if (opCode == "00" + GetRegisterOpCode("F") + GetRegisterOpCode("E"))
                return OpCode.MOV_E_TO_F;
            else if (opCode == "00" + GetRegisterOpCode("G") + GetRegisterOpCode("E"))
                return OpCode.MOV_E_TO_G;
            else if (opCode == "00" + GetRegisterOpCode("H") + GetRegisterOpCode("E"))
                return OpCode.MOV_E_TO_H;
            else if (opCode == "00" + GetRegisterOpCode("XL") + GetRegisterOpCode("E"))
                return OpCode.MOV_E_TO_XL;
            else if (opCode == "00" + GetRegisterOpCode("XH") + GetRegisterOpCode("E"))
                return OpCode.MOV_E_TO_XH;

            else if (opCode == "00" + GetRegisterOpCode("D") + GetRegisterOpCode("F"))
                return OpCode.MOV_F_TO_D;
            else if (opCode == "00" + GetRegisterOpCode("E") + GetRegisterOpCode("F"))
                return OpCode.MOV_F_TO_E;
            else if (opCode == "00" + GetRegisterOpCode("G") + GetRegisterOpCode("F"))
                return OpCode.MOV_F_TO_G;
            else if (opCode == "00" + GetRegisterOpCode("H") + GetRegisterOpCode("F"))
                return OpCode.MOV_F_TO_H;
            else if (opCode == "00" + GetRegisterOpCode("XL") + GetRegisterOpCode("F"))
                return OpCode.MOV_F_TO_XL;
            else if (opCode == "00" + GetRegisterOpCode("XH") + GetRegisterOpCode("F"))
                return OpCode.MOV_F_TO_XH;

            else if (opCode == "00" + GetRegisterOpCode("D") + GetRegisterOpCode("G"))
                return OpCode.MOV_G_TO_D;
            else if (opCode == "00" + GetRegisterOpCode("E") + GetRegisterOpCode("G"))
                return OpCode.MOV_G_TO_E;
            else if (opCode == "00" + GetRegisterOpCode("F") + GetRegisterOpCode("G"))
                return OpCode.MOV_G_TO_F;
            else if (opCode == "00" + GetRegisterOpCode("H") + GetRegisterOpCode("G"))
                return OpCode.MOV_G_TO_H;
            else if (opCode == "00" + GetRegisterOpCode("XL") + GetRegisterOpCode("G"))
                return OpCode.MOV_G_TO_XL;
            else if (opCode == "00" + GetRegisterOpCode("XH") + GetRegisterOpCode("G"))
                return OpCode.MOV_G_TO_XH;

            else if (opCode == "00" + GetRegisterOpCode("D") + GetRegisterOpCode("H"))
                return OpCode.MOV_H_TO_D;
            else if (opCode == "00" + GetRegisterOpCode("E") + GetRegisterOpCode("H"))
                return OpCode.MOV_H_TO_E;
            else if (opCode == "00" + GetRegisterOpCode("F") + GetRegisterOpCode("H"))
                return OpCode.MOV_H_TO_F;
            else if (opCode == "00" + GetRegisterOpCode("G") + GetRegisterOpCode("H"))
                return OpCode.MOV_H_TO_G;
            else if (opCode == "00" + GetRegisterOpCode("XL") + GetRegisterOpCode("H"))
                return OpCode.MOV_H_TO_XL;
            else if (opCode == "00" + GetRegisterOpCode("XH") + GetRegisterOpCode("H"))
                return OpCode.MOV_H_TO_XH;

            else if (opCode == "00" + GetRegisterOpCode("D") + GetRegisterOpCode("XL"))
                return OpCode.MOV_XL_TO_D;
            else if (opCode == "00" + GetRegisterOpCode("E") + GetRegisterOpCode("XL"))
                return OpCode.MOV_XL_TO_E;
            else if (opCode == "00" + GetRegisterOpCode("F") + GetRegisterOpCode("XL"))
                return OpCode.MOV_XL_TO_F;
            else if (opCode == "00" + GetRegisterOpCode("G") + GetRegisterOpCode("XL"))
                return OpCode.MOV_XL_TO_G;
            else if (opCode == "00" + GetRegisterOpCode("H") + GetRegisterOpCode("XL"))
                return OpCode.MOV_XL_TO_H;
            else if (opCode == "00" + GetRegisterOpCode("XH") + GetRegisterOpCode("XL"))
                return OpCode.MOV_XL_TO_XH;

            else if (opCode == "00" + GetRegisterOpCode("D") + GetRegisterOpCode("XH"))
                return OpCode.MOV_XH_TO_D;
            else if (opCode == "00" + GetRegisterOpCode("E") + GetRegisterOpCode("XH"))
                return OpCode.MOV_XH_TO_E;
            else if (opCode == "00" + GetRegisterOpCode("F") + GetRegisterOpCode("XH"))
                return OpCode.MOV_XH_TO_F;
            else if (opCode == "00" + GetRegisterOpCode("G") + GetRegisterOpCode("XH"))
                return OpCode.MOV_XH_TO_G;
            else if (opCode == "00" + GetRegisterOpCode("H") + GetRegisterOpCode("XH"))
                return OpCode.MOV_XH_TO_H;
            else if (opCode == "00" + GetRegisterOpCode("XL") + GetRegisterOpCode("XH"))
                return OpCode.MOV_XH_TO_XL;

            else if (opCode == "01" + GetRegisterOpCode("X") + GetRegisterOpCode("M"))
                return OpCode.MOV_M_TO_X;
            else if (opCode == "01" + GetRegisterOpCode("J") + GetRegisterOpCode("M"))
                return OpCode.MOV_M_TO_J;
            else if (opCode == "01" + GetRegisterOpCode("SP") + GetRegisterOpCode("M"))
                return OpCode.MOV_M_TO_SP;
            else if (opCode == "01" + GetRegisterOpCode("BP") + GetRegisterOpCode("M"))
                return OpCode.MOV_M_TO_BP;
            else if (opCode == "01" + GetRegisterOpCode("Y") + GetRegisterOpCode("M"))
                return OpCode.MOV_M_TO_Y;
            else if (opCode == "01" + GetRegisterOpCode("Z") + GetRegisterOpCode("M"))
                return OpCode.MOV_M_TO_Z;
            else if (opCode == "01" + GetRegisterOpCode("PC") + GetRegisterOpCode("M"))
                return OpCode.MOV_M_TO_PC;

            else if (opCode == "01" + GetRegisterOpCode("M") + GetRegisterOpCode("X"))
                return OpCode.MOV_X_TO_M;
            else if (opCode == "01" + GetRegisterOpCode("J") + GetRegisterOpCode("X"))
                return OpCode.MOV_X_TO_J;
            else if (opCode == "01" + GetRegisterOpCode("SP") + GetRegisterOpCode("X"))
                return OpCode.MOV_X_TO_SP;
            else if (opCode == "01" + GetRegisterOpCode("BP") + GetRegisterOpCode("X"))
                return OpCode.MOV_X_TO_BP;
            else if (opCode == "01" + GetRegisterOpCode("Y") + GetRegisterOpCode("X"))
                return OpCode.MOV_X_TO_Y;
            else if (opCode == "01" + GetRegisterOpCode("Z") + GetRegisterOpCode("X"))
                return OpCode.MOV_X_TO_Z;

            else if (opCode == "01" + GetRegisterOpCode("M") + GetRegisterOpCode("J"))
                return OpCode.MOV_J_TO_M;
            else if (opCode == "01" + GetRegisterOpCode("X") + GetRegisterOpCode("J"))
                return OpCode.MOV_J_TO_X;
            else if (opCode == "01" + GetRegisterOpCode("SP") + GetRegisterOpCode("J"))
                return OpCode.MOV_J_TO_SP;
            else if (opCode == "01" + GetRegisterOpCode("BP") + GetRegisterOpCode("J"))
                return OpCode.MOV_J_TO_BP;
            else if (opCode == "01" + GetRegisterOpCode("Y") + GetRegisterOpCode("J"))
                return OpCode.MOV_J_TO_Y;
            else if (opCode == "01" + GetRegisterOpCode("Z") + GetRegisterOpCode("J"))
                return OpCode.MOV_J_TO_Z;

            else if (opCode == "01" + GetRegisterOpCode("M") + GetRegisterOpCode("SP"))
                return OpCode.MOV_SP_TO_M;
            else if (opCode == "01" + GetRegisterOpCode("X") + GetRegisterOpCode("SP"))
                return OpCode.MOV_SP_TO_X;
            else if (opCode == "01" + GetRegisterOpCode("J") + GetRegisterOpCode("SP"))
                return OpCode.MOV_SP_TO_J;
            else if (opCode == "01" + GetRegisterOpCode("BP") + GetRegisterOpCode("SP"))
                return OpCode.MOV_SP_TO_BP;
            else if (opCode == "01" + GetRegisterOpCode("Y") + GetRegisterOpCode("SP"))
                return OpCode.MOV_SP_TO_Y;
            else if (opCode == "01" + GetRegisterOpCode("Z") + GetRegisterOpCode("SP"))
                return OpCode.MOV_SP_TO_Z;

            else if (opCode == "01" + GetRegisterOpCode("X") + GetRegisterOpCode("PC"))
                return OpCode.MOV_PC_TO_X;

            else if (opCode == "01" + GetRegisterOpCode("M") + GetRegisterOpCode("BP"))
                return OpCode.MOV_BP_TO_M;
            else if (opCode == "01" + GetRegisterOpCode("X") + GetRegisterOpCode("BP"))
                return OpCode.MOV_BP_TO_X;
            else if (opCode == "01" + GetRegisterOpCode("J") + GetRegisterOpCode("BP"))
                return OpCode.MOV_BP_TO_J;
            else if (opCode == "01" + GetRegisterOpCode("SP") + GetRegisterOpCode("BP"))
                return OpCode.MOV_BP_TO_SP;
            else if (opCode == "01" + GetRegisterOpCode("Y") + GetRegisterOpCode("BP"))
                return OpCode.MOV_BP_TO_Y;
            else if (opCode == "01" + GetRegisterOpCode("Z") + GetRegisterOpCode("BP"))
                return OpCode.MOV_BP_TO_Z;

            else if (opCode == "01" + GetRegisterOpCode("M") + GetRegisterOpCode("Y"))
                return OpCode.MOV_Y_TO_M;
            else if (opCode == "01" + GetRegisterOpCode("X") + GetRegisterOpCode("Y"))
                return OpCode.MOV_Y_TO_X;
            else if (opCode == "01" + GetRegisterOpCode("J") + GetRegisterOpCode("Y"))
                return OpCode.MOV_Y_TO_J;
            else if (opCode == "01" + GetRegisterOpCode("SP") + GetRegisterOpCode("Y"))
                return OpCode.MOV_Y_TO_SP;
            else if (opCode == "01" + GetRegisterOpCode("BP") + GetRegisterOpCode("Y"))
                return OpCode.MOV_Y_TO_BP;
            else if (opCode == "01" + GetRegisterOpCode("Z") + GetRegisterOpCode("Y"))
                return OpCode.MOV_Y_TO_Z;

            else if (opCode == "01" + GetRegisterOpCode("M") + GetRegisterOpCode("Z"))
                return OpCode.MOV_Z_TO_M;
            else if (opCode == "01" + GetRegisterOpCode("X") + GetRegisterOpCode("Z"))
                return OpCode.MOV_Z_TO_X;
            else if (opCode == "01" + GetRegisterOpCode("J") + GetRegisterOpCode("Z"))
                return OpCode.MOV_Z_TO_J;
            else if (opCode == "01" + GetRegisterOpCode("SP") + GetRegisterOpCode("Z"))
                return OpCode.MOV_Z_TO_SP;
            else if (opCode == "01" + GetRegisterOpCode("BP") + GetRegisterOpCode("Z"))
                return OpCode.MOV_Z_TO_BP;
            else if (opCode == "01" + GetRegisterOpCode("Y") + GetRegisterOpCode("Z"))
                return OpCode.MOV_Z_TO_Y;

            else if (opCode == "10101110")
                return OpCode.MOV_ALU_C_TO_A;
            else if (opCode == "10101111")
                return OpCode.MOV_ALU_C_TO_B;

            else if (opCode == "10010000")
                return OpCode.LOAD_D;
            else if (opCode == "10010001")
                return OpCode.LOAD_E;
            else if (opCode == "10010010")
                return OpCode.LOAD_F;
            else if (opCode == "10010011")
                return OpCode.LOAD_G;
            else if (opCode == "10010100")
                return OpCode.LOAD_H;
            else if (opCode == "10010110")
                return OpCode.LOAD_XL;
            else if (opCode == "10010111")
                return OpCode.LOAD_XH;

            else if (opCode == "10011000")
                return OpCode.STORE_D;
            else if (opCode == "10011001")
                return OpCode.STORE_E;
            else if (opCode == "10011010")
                return OpCode.STORE_F;
            else if (opCode == "10011011")
                return OpCode.STORE_G;
            else if (opCode == "10011100")
                return OpCode.STORE_H;
            else if (opCode == "10011110")
                return OpCode.STORE_XL;
            else if (opCode == "10011111")
                return OpCode.STORE_XH;

            else if (opCode == "11000100")
                return OpCode.SAVE_FLAGS;
            else if (opCode == "11000101")
                return OpCode.RESTORE_FLAGS;

            else if (opCode == "11000010")
                return OpCode.JMP;
            else if (opCode == "11000000")
                return OpCode.JZ;
            else if (opCode == "11000001")
                return OpCode.JNZ;
            else if (opCode == "11001011")
                return OpCode.JNS;

            else if (opCode == "11001000")
                return OpCode.ADDER_16BIT;

            else if (opCode == "11001100")
                return OpCode.IN_A;
            else if (opCode == "11001101")
                return OpCode.IN_B;

            else if (opCode == "11001110")
                return OpCode.OUT_C;

            else if (opCode == "11001111")
                return OpCode.OUT_D;

            else if (opCode == "11010000")
                return OpCode.INT;

            else if (opCode == "11000011")
                return OpCode.HLT;

            throw new ArgumentException("Invalid OpCode provided");
        }

        private string GetRegisterOpCode(string Register)
        {
            switch (Register)
            {
                case "D": return "000";
                case "E": return "001";
                case "F": return "010";
                case "G": return "011";
                case "H": return "100";
                case "XL": return "110";
                case "XH": return "111";
                case "M": return "000";
                case "X": return "001";
                case "J": return "010";
                case "SP": return "011";
                case "PC": return "100";
                case "BP": return "101";
                case "Y": return "110";
                case "Z": return "111";
            }

            throw new ArgumentException("Invalid Register specified.");
        }
    }
}
