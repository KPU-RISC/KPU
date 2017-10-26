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
        /// PUSH 0xAB
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Result VisitPUSH_CONST_HEX1(HighLevelAssemblyParser.PUSH_CONST_HEX1Context context)
        {
            string hexValue = context.HexValue().GetText();
            string binaryValue = HexToBinary(hexValue);

            // 1. Set the register "XL" to "11111111"
            assembly.Add(";; BEGIN PUSH 0x" + hexValue + " (PUSH_CONST_HEX1)");
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
            assembly.Add(";; END PUSH 0x" + hexValue + " (PUSH_CONST_HEX1)");

            return base.VisitPUSH_CONST_HEX1(context);
        }
    }
}
