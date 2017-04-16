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
        /// RCL
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Result VisitRCL(LowLevelAssemblyParser.RCLContext context)
        {
            assembly.Add("10001011 ; RCL");

            return base.VisitRCL(context);
        }
    }
}
