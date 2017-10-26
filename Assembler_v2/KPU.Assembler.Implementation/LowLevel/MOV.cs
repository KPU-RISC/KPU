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
        /// MOV D, E
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Result VisitMOV(LowLevelAssemblyParser.MOVContext context)
        {
            string destinationRegister = context.register_8bit(0).GetText();
            string sourceRegister = context.register_8bit(1).GetText();

            string opcode = "00";
            opcode += GetRegisterOpCode_GeneralPurpose(destinationRegister);
            opcode += GetRegisterOpCode_GeneralPurpose(sourceRegister);
            opcode += " ; MOV " + destinationRegister + ", " + sourceRegister;
            assembly.Add(opcode);

            return base.VisitMOV(context);
        }
    }
}
