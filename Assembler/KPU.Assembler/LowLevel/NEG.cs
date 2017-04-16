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
        /// NEG
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Result VisitNEG(LowLevelAssemblyParser.NEGContext context)
        {
            assembly.Add("10001001 ; NEG");

            return base.VisitNEG(context);
        }
    }
}
