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
        /// JNZ
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Result VisitJNZ(LowLevelAssemblyParser.JNZContext context)
        {
            assembly.Add("11000001 ; JNZ" + context.JumpLabel().GetText());

            return base.VisitJNZ(context);
        }
    }
}
