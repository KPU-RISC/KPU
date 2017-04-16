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
        /// NOT D
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Result VisitNOT_R8(HighLevelAssemblyParser.NOT_R8Context context)
        {
            string sourceRegister = context.register_8bit().GetText();

            // Add the assembly opcodes
            assembly.Add(";; BEGIN NOT " + sourceRegister + " (NOT_R8)");
            assembly.Add("MOV_ALU_IN A, " + sourceRegister);
            assembly.Add("NOT");
            assembly.Add("MOV_ALU_OUT " + sourceRegister);
            assembly.Add(";; END NOT " + sourceRegister + " (NOT_R8)");

            return base.VisitNOT_R8(context);
        }
    }
}