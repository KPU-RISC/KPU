using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPU_Assembler
{
    public partial class HighLevelAssemblyVisitor<Result>
    {
        /// <summary>
        /// :JUMPLABEL
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Result VisitJMP_LABEL(HighLevelAssemblyParser.JMP_LABELContext context)
        {
            // Emits just the jump label (":JUMPLABEL") without any changes
            assembly.Add("NOP" + context.JumpLabel().GetText());

            return base.VisitJMP_LABEL(context);
        }
    }
}
