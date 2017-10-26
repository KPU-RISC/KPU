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
        /// NOP:JUMP_LABEL
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Result VisitJMP_LABEL(LowLevelAssemblyParser.JMP_LABELContext context)
        {
            assembly.Add("10000000 ; " + context.JumpLabel().GetText());

            return base.VisitJMP_LABEL(context);
        }
    }
}
