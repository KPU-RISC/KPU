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
        /// HLT
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Result VisitLOAD(LowLevelAssemblyParser.LOADContext context)
        {
            string sourceRegister = context.register_8bit().GetText();

            string opcode = "10010";
            opcode += GetRegisterOpCode_GeneralPurpose(sourceRegister);
            opcode += " ; LOAD " + sourceRegister;
            assembly.Add(opcode);

            return base.VisitLOAD(context);
        }
    }
}
