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
        /// SAR D
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Result VisitSAR_R8(HighLevelAssemblyParser.SAR_R8Context context)
        {
            string sourceRegister = context.register_8bit().GetText();

            // Add the assembly opcodes
            assembly.Add(";; BEGIN SAR " + sourceRegister + " (SAR_R8)");
            assembly.Add("MOV_ALU_IN A, " + sourceRegister);
            assembly.Add("SAR");
            assembly.Add("MOV_ALU_OUT " + sourceRegister);
            assembly.Add(";; END SAR " + sourceRegister + " (SAR_R8)");

            return base.VisitSAR_R8(context);
        }
    }
}
