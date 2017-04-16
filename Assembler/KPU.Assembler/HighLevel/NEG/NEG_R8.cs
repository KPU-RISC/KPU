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
        /// NEG D
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Result VisitNEG_R8(HighLevelAssemblyParser.NEG_R8Context context)
        {
            string sourceRegister = context.register_8bit().GetText();

            // Add the assembly opcodes
            assembly.Add(";; BEGIN NEG " + sourceRegister + " (NEG_R8)");
            assembly.Add("MOV_ALU_IN A, " + sourceRegister);
            assembly.Add("NEG");
            assembly.Add("MOV_ALU_OUT " + sourceRegister);
            assembly.Add(";; END NEG " + sourceRegister + " (NEG_R8)");

            return base.VisitNEG_R8(context);
        }
    }
}
