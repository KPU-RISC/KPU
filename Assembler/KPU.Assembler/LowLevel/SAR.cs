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
        /// SAR
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Result VisitSAR(LowLevelAssemblyParser.SARContext context)
        {
            assembly.Add("10001101 ; SAR");

            return base.VisitSAR(context);
        }
    }
}
