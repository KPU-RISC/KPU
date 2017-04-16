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
        public override Result VisitSAVE_FLAGS(LowLevelAssemblyParser.SAVE_FLAGSContext context)
        {
            assembly.Add("11000100 ; SAVE_FLAGS");

            return base.VisitSAVE_FLAGS(context);
        }
    }
}
