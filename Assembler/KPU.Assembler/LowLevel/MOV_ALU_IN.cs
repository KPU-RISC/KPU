using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPU_Assembler
{
    public partial class LowLevelAssemblyVisitor<Result> : LowLevelAssemblyBaseVisitor<Result>
    {
        /// <summary>
        /// MOV_ALU_IN A, D
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Result VisitMOV_ALU_IN(LowLevelAssemblyParser.MOV_ALU_INContext context)
        {
            string destinationRegister = context.register_ab().GetText();
            string sourceRegister = context.register_8bit().GetText();

            string opcode = "1011";
            opcode += GetRegisterOpCode_ALU(destinationRegister);
            opcode += GetRegisterOpCode_GeneralPurpose(sourceRegister);
            opcode += " ; MOV_ALU_IN " + destinationRegister + ", " + sourceRegister;
            assembly.Add(opcode);

            return base.VisitMOV_ALU_IN(context);
        }
    }
}
