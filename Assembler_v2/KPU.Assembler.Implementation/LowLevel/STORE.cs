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
        public override Result VisitSTORE(LowLevelAssemblyParser.STOREContext context)
        {
            string sourceRegister = context.register_8bit().GetText();

            string opcode = "10011";
            opcode += GetRegisterOpCode_GeneralPurpose(sourceRegister);
            opcode += " ; STORE " + sourceRegister;
            assembly.Add(opcode);

            return base.VisitSTORE(context);
        }
    }
}
