using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPU_Assembler
{
    public partial class LowLevelAssemblyVisitor<Result> : LowLevelAssemblyBaseVisitor<Result>
    {
        public override Result VisitMOV_ALU_OUT(LowLevelAssemblyParser.MOV_ALU_OUTContext context)
        {
            string destinationRegister = context.register_8bit().GetText();

            string opcode = "11011";
            opcode += GetRegisterOpCode_GeneralPurpose(destinationRegister);
            opcode += " ; MOV_ALU_OUT " + destinationRegister;
            assembly.Add(opcode);

            return base.VisitMOV_ALU_OUT(context);
        }
    }
}
