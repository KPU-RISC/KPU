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
        /// XOR D, E
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Result VisitXOR_R8_R8(HighLevelAssemblyParser.XOR_R8_R8Context context)
        {
            string sourceRegister = context.register_8bit(1).GetText();
            string destinationRegister = context.register_8bit(0).GetText();

            // Add the assembly opcodes
            assembly.Add(";; BEGIN XOR " + destinationRegister + ", " + sourceRegister + " (XOR_R8_R8)");
            assembly.Add("MOV_ALU_IN A, " + destinationRegister);
            assembly.Add("MOV_ALU_IN B, " + sourceRegister);
            assembly.Add("XOR");
            assembly.Add("MOV_ALU_OUT " + destinationRegister);
            assembly.Add(";; END XOR " + destinationRegister + ", " + sourceRegister + " (XOR_R8_R8)");

            return base.VisitXOR_R8_R8(context);
        }
    }
}
