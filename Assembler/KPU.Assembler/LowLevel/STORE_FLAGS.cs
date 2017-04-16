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
        /// STORE_FLAGS
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Result VisitSTORE_FLAGS(LowLevelAssemblyParser.STORE_FLAGSContext context)
        {
            assembly.Add("11001001 ; STORE_FLAGS");

            return base.VisitSTORE_FLAGS(context);
        }
    }
}
