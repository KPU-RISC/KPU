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
        /// LOAD_FLAGS
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Result VisitLOAD_FLAGS(LowLevelAssemblyParser.LOAD_FLAGSContext context)
        {
            assembly.Add("11001010 ; LOAD_FLAGS");

            return base.VisitLOAD_FLAGS(context);
        }
    }
}
