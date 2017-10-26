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
        /// PUSH 10101010b
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Result VisitPUSH_CONST_BINARY(HighLevelAssemblyParser.PUSH_CONST_BINARYContext context)
        {
            string binaryValue = context.EightBitBinaryValue().GetText().Substring(0, 8);

            // 1. Set the register "XL" to "11111111"
            assembly.Add(";; BEGIN PUSH " + binaryValue + "b (PUSH_CONST_BINARY)");
            assembly.Add("SAVE_FLAGS");
            assembly.AddRange(GenerateMnemonics_MOV8("MOV8 XL, \"11111111\""));

            // 2. Set the register "XH" to "11111111"
            assembly.AddRange(GenerateMnemonics_MOV8("MOV8 XH, \"11111111\""));

            // 3. Decrement the stack pointer by 1
            assembly.Add("MOV16 J, X");
            assembly.Add("MOV16 X, SP");
            assembly.Add("16BIT_ADDER");
            assembly.Add("MOV16 SP, X");

            // 4. Store the value of the specified register onto the stack
            assembly.Add("MOV16 M, SP");
            assembly.AddRange(GenerateMnemonics_MOV8("MOV8 XL, \"" + binaryValue + "\"")); 
            assembly.Add("STORE XL");
            assembly.Add("RESTORE_FLAGS");
            assembly.Add(";; END PUSH " + binaryValue + "b (PUSH_CONST_BINARY)");

            return base.VisitPUSH_CONST_BINARY(context);
        }
    }
}
