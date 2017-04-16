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
        /// HLT
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Result VisitHLT(LowLevelAssemblyParser.HLTContext context)
        {
            assembly.Add("11000011 ; HLT");

            return base.VisitHLT(context);
        }
    }
}
