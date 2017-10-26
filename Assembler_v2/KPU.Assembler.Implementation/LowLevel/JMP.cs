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
        /// JMP
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Result VisitJMP(LowLevelAssemblyParser.JMPContext context)
        {
            assembly.Add("11000010 ; JMP" + context.JumpLabel().GetText());

            return base.VisitJMP(context);
        }
    }
}
