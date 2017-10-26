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
        /// DEC F
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Result VisitDEC_R8(HighLevelAssemblyParser.DEC_R8Context context)
        {
            string sourceRegister = context.register_8bit().GetText();

            // Create the binary value 11111111b
            assembly.Add(";; BEGIN DEC " + sourceRegister + " (DEC_R8)");
            assembly.Add("SET A, \"1111\"");
            assembly.Add("SET B, \"1111\"");
            assembly.Add("MOV8");

            // Move the generated bit value to register B
            // assembly.Add("MOV_ALU_C_TO_AB B");
            assembly.Add("MOV_ALU_OUT XL");
            assembly.Add("MOV_ALU_IN B, XL");

            // Move the decrement register to register A
            assembly.Add("MOV_ALU_IN A, " + sourceRegister);

            // Perform the addition for the subtraction
            assembly.Add("ADD");

            // Move the subtracted value back to the original register
            assembly.Add("MOV_ALU_OUT " + sourceRegister);
            assembly.Add(";; END DEC " + sourceRegister + " (DEC_R8)");

            return base.VisitDEC_R8(context);
        }
    }
}
