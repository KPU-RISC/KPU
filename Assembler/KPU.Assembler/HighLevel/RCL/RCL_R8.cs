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
        /// RCL D
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Result VisitRCL_R8(HighLevelAssemblyParser.RCL_R8Context context)
        {
            string sourceRegister = context.register_8bit().GetText();

            // Add the assembly opcodes
            assembly.Add(";; BEGIN RCL " + sourceRegister + " (RCL_R8)");
            assembly.Add("MOV_ALU_IN A, " + sourceRegister);
            assembly.Add("SAVE_FLAGS");
            assembly.Add("RCL");
            assembly.Add("MOV_ALU_OUT " + sourceRegister);
            assembly.Add(";; END RCL " + sourceRegister + " (RCL_R8)");

            return base.VisitRCL_R8(context);
        }
    }
}
