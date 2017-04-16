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
        public override Result VisitFLAGS_TO_OUTBUFFER(LowLevelAssemblyParser.FLAGS_TO_OUTBUFFERContext context)
        {
            assembly.Add("11000110 ; FLAGS_TO_OUTBUFFER");

            return base.VisitFLAGS_TO_OUTBUFFER(context);
        }
    }
}
