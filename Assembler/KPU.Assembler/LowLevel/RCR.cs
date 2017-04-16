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
        /// RCR
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Result VisitRCR(LowLevelAssemblyParser.RCRContext context)
        {
            assembly.Add("10001110 ; RCR");

            return base.VisitRCR(context);
        }
    }
}
