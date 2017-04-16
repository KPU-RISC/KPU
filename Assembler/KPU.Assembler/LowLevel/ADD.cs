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
        /// ADD
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Result VisitADD(LowLevelAssemblyParser.ADDContext context)
        {
            assembly.Add("10000100 ; ADD");

            return base.VisitADD(context);
        }
    }
}
