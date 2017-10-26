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
        /// JNC
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Result VisitJNC(LowLevelAssemblyParser.JNCContext context)
        {
            assembly.Add("11010001 ; JNC" + context.JumpLabel().GetText());

            return base.VisitJNC(context);
        }
    }
}
