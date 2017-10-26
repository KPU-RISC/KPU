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
        /// JZ
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Result VisitJZ(LowLevelAssemblyParser.JZContext context)
        {
            assembly.Add("11000000 ; JZ" + context.JumpLabel().GetText());

            return base.VisitJZ(context);
        }
    }
}
