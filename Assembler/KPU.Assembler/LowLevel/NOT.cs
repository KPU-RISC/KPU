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
        /// NOT
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Result VisitNOT(LowLevelAssemblyParser.NOTContext context)
        {
            assembly.Add("10000101 ; NOT");

            return base.VisitNOT(context);
        }
    }
}