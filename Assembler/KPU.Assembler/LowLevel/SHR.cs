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
        /// SHR
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Result VisitSHR(LowLevelAssemblyParser.SHRContext context)
        {
            assembly.Add("10001100 ; SHR");

            return base.VisitSHR(context);
        }
    }
}
