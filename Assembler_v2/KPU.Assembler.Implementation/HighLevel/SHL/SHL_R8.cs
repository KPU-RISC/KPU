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
        /// SHL D
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Result VisitSHL_R8(HighLevelAssemblyParser.SHL_R8Context context)
        {
            string sourceRegister = context.register_8bit().GetText();

            // Add the assembly opcodes
            assembly.Add(";; BEGIN SHL " + sourceRegister + " (SHL_R8)");
            assembly.Add("MOV_ALU_IN A, " + sourceRegister);
            assembly.Add("SHL");
            assembly.Add("MOV_ALU_OUT " + sourceRegister);
            assembly.Add(";; END SHL " + sourceRegister + " (SHL_R8)");

            return base.VisitSHL_R8(context);
        }
    }
}
