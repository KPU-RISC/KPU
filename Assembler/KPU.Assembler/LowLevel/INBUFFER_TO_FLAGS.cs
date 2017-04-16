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
        /// INBUFFER_TO_FLAGS
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Result VisitINBUFFER_TO_FLAGS(LowLevelAssemblyParser.INBUFFER_TO_FLAGSContext context)
        {
            assembly.Add("11000111 ; INBUFFER_TO_FLAGS");

            return base.VisitINBUFFER_TO_FLAGS(context);
        }
    }
}
