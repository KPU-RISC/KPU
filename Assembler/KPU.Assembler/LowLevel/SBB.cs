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
        /// SBB
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Result VisitSBB(LowLevelAssemblyParser.SBBContext context)
        {
            assembly.Add("10001010 ; SBB");

            return base.VisitSBB(context);
        }
    }
}
