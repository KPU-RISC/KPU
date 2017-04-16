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
        /// AND
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Result VisitAND(LowLevelAssemblyParser.ANDContext context)
        {
            assembly.Add("10000011 ; AND");

            return base.VisitAND(context);
        }
    }
}