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
        /// SHR D
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Result VisitSHR_R8(HighLevelAssemblyParser.SHR_R8Context context)
        {
            string sourceRegister = context.register_8bit().GetText();

            // Add the assembly opcodes
            assembly.Add(";; BEGIN SHR " + sourceRegister + " (SHR_R8)");
            assembly.Add("MOV_ALU_IN A, " + sourceRegister);
            assembly.Add("SHR");
            assembly.Add("MOV_ALU_OUT " + sourceRegister);
            assembly.Add(";; END SHR " + sourceRegister + " (SHR_R8)");

            return base.VisitSHR_R8(context);
        }
    }
}
