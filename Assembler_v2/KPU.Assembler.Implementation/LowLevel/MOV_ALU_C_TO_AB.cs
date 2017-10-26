using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPU_Assembler
{
    public partial class LowLevelAssemblyVisitor<Result> : LowLevelAssemblyBaseVisitor<Result>
    {
        public override Result VisitMOV_ALU_C_TO_AB(LowLevelAssemblyParser.MOV_ALU_C_TO_ABContext context)
        {
            string destinationRegister = context.register_ab().GetText();

            string opcode = "1010111";
            opcode += GetRegisterOpCode_ALU(destinationRegister);
            opcode += " ; MOV_ALU_C_TO_AB " + destinationRegister;
            assembly.Add(opcode);

            return base.VisitMOV_ALU_C_TO_AB(context);
        }
    }
}
