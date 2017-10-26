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
        /// SAVE_FLAGS
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Result VisitRESTORE_FLAGS(LowLevelAssemblyParser.RESTORE_FLAGSContext context)
        {
            assembly.Add("11000101 ; RESTORE_FLAGS");

            return base.VisitRESTORE_FLAGS(context);
        }
    }
}
