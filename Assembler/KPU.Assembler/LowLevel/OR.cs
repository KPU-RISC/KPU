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
        /// OR
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Result VisitOR(LowLevelAssemblyParser.ORContext context)
        {
            assembly.Add("10000010 ; OR");

            return base.VisitOR(context);
        }
    }
}
