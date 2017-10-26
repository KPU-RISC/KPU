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
        /// JNS
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Result VisitJNS(LowLevelAssemblyParser.JNSContext context)
        {
            assembly.Add("11001011 ; JNS" + context.JumpLabel().GetText());

            return base.VisitJNS(context);
        }
    }
}
