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
        /// RCR D
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Result VisitRCR_R8(HighLevelAssemblyParser.RCR_R8Context context)
        {
            string sourceRegister = context.register_8bit().GetText();

            // Add the assembly opcodes
            assembly.Add(";; BEGIN RCR " + sourceRegister + " (RCR_R8)");
            assembly.Add("MOV_ALU_IN A, " + sourceRegister);
            assembly.Add("SAVE_FLAGS");
            assembly.Add("RCR");
            assembly.Add("MOV_ALU_OUT " + sourceRegister);
            assembly.Add(";; END RCR " + sourceRegister + " (RCR_R8)");

            return base.VisitRCR_R8(context);
        }
    }
}
