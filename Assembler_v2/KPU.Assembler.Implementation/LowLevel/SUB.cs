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
        /// SUB
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Result VisitSUB(LowLevelAssemblyParser.SUBContext context)
        {
            assembly.Add("10001000 ; SUB");

            return base.VisitSUB(context);
        }
    }
}
