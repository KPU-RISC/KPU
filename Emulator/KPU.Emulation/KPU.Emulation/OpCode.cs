using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPU.Emulation
{
    public enum OpCode
    {
        SET_A,
        SET_B,
        MOV8,
        ADD,
        AND,
        ADC,
        NEG,
        NOP,
        NOT,
        OR,
        RCL,
        RCR,
        SAR,
        SBB,
        SHL,
        SHR,
        SUB,
        XOR,

        MOV_ALU_C_TO_A,
        MOV_ALU_C_TO_B,

        MOV_ALU_OUT_D,
        MOV_ALU_OUT_E,
        MOV_ALU_OUT_F,
        MOV_ALU_OUT_G,
        MOV_ALU_OUT_H,
        MOV_ALU_OUT_XL,
        MOV_ALU_OUT_XH,

        MOV_ALU_IN_A_D,
        MOV_ALU_IN_A_E,
        MOV_ALU_IN_A_F,
        MOV_ALU_IN_A_G,
        MOV_ALU_IN_A_H,
        MOV_ALU_IN_A_XL,
        MOV_ALU_IN_A_XH,

        MOV_ALU_IN_B_D,
        MOV_ALU_IN_B_E,
        MOV_ALU_IN_B_F,
        MOV_ALU_IN_B_G,
        MOV_ALU_IN_B_H,
        MOV_ALU_IN_B_XL,
        MOV_ALU_IN_B_XH,

        MOV_D_TO_E,
        MOV_D_TO_F,
        MOV_D_TO_G,
        MOV_D_TO_H,
        MOV_D_TO_XL,
        MOV_D_TO_XH,

        MOV_E_TO_D,
        MOV_E_TO_F,
        MOV_E_TO_G,
        MOV_E_TO_H,
        MOV_E_TO_XL,
        MOV_E_TO_XH,

        MOV_F_TO_D,
        MOV_F_TO_E,
        MOV_F_TO_G,
        MOV_F_TO_H,
        MOV_F_TO_XL,
        MOV_F_TO_XH,

        MOV_G_TO_D,
        MOV_G_TO_E,
        MOV_G_TO_F,
        MOV_G_TO_H,
        MOV_G_TO_XL,
        MOV_G_TO_XH,

        MOV_H_TO_D,
        MOV_H_TO_E,
        MOV_H_TO_F,
        MOV_H_TO_G,
        MOV_H_TO_XL,
        MOV_H_TO_XH,

        MOV_XL_TO_D,
        MOV_XL_TO_E,
        MOV_XL_TO_F,
        MOV_XL_TO_G,
        MOV_XL_TO_H,
        MOV_XL_TO_XH,

        MOV_XH_TO_D,
        MOV_XH_TO_E,
        MOV_XH_TO_F,
        MOV_XH_TO_G,
        MOV_XH_TO_H,
        MOV_XH_TO_XL,

        MOV_M_TO_X,
        MOV_M_TO_J,
        MOV_M_TO_SP,
        MOV_M_TO_BP,
        MOV_M_TO_Y,
        MOV_M_TO_Z,
        MOV_M_TO_PC,

        MOV_X_TO_M,
        MOV_X_TO_J,
        MOV_X_TO_SP,
        MOV_X_TO_BP,
        MOV_X_TO_Y,
        MOV_X_TO_Z,

        MOV_J_TO_M,
        MOV_J_TO_X,
        MOV_J_TO_SP,
        MOV_J_TO_BP,
        MOV_J_TO_Y,
        MOV_J_TO_Z,

        MOV_SP_TO_M,
        MOV_SP_TO_X,
        MOV_SP_TO_J,
        MOV_SP_TO_BP,
        MOV_SP_TO_Y,
        MOV_SP_TO_Z,

        MOV_BP_TO_M,
        MOV_BP_TO_X,
        MOV_BP_TO_J,
        MOV_BP_TO_SP,
        MOV_BP_TO_Y,
        MOV_BP_TO_Z,

        MOV_Y_TO_M,
        MOV_Y_TO_X,
        MOV_Y_TO_J,
        MOV_Y_TO_SP,
        MOV_Y_TO_BP,
        MOV_Y_TO_Z,

        MOV_Z_TO_M,
        MOV_Z_TO_X,
        MOV_Z_TO_J,
        MOV_Z_TO_SP,
        MOV_Z_TO_BP,
        MOV_Z_TO_Y,

        MOV_PC_TO_X,

        LOAD_D,
        LOAD_E,
        LOAD_F,
        LOAD_G,
        LOAD_H,
        LOAD_XL,
        LOAD_XH,

        STORE_D,
        STORE_E,
        STORE_F,
        STORE_G,
        STORE_H,
        STORE_XL,
        STORE_XH,

        JMP,
        JZ,
        JNZ,
        JNS,

        IN_A,
        IN_B,

        OUT_C,
        OUT_D,

        ADDER_16BIT,

        SAVE_FLAGS,
        RESTORE_FLAGS,

        INT,

        HLT
    }
}
