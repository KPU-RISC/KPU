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
        /// INC F
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Result VisitINC_R8(HighLevelAssemblyParser.INC_R8Context context)
        {
            string sourceRegister = context.register_8bit().GetText();

            // Add the assembly opcodes
            assembly.Add(";; BEGIN INC " + sourceRegister + " (INC_R8)");
            assembly.Add("MOV_ALU_IN A, " + sourceRegister);
            assembly.Add("SET B, \"0001\"");
            assembly.Add("ADD");
            assembly.Add("MOV_ALU_OUT " + sourceRegister);
            assembly.Add(";; END INC " + sourceRegister + " (INC_R8)");

            return base.VisitINC_R8(context);
        }
    }
}
