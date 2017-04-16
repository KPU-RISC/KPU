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
        /// PUSH 5
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Result VisitPUSH_CONST_DECIMAL(HighLevelAssemblyParser.PUSH_CONST_DECIMALContext context)
        {
            int decimalValue = int.Parse(context.@int().GetText());
            string binaryValue = IntToBinary(decimalValue, 8);

            // 1. Set the register "XL" to "11111111"
            assembly.Add(";; BEGIN PUSH " + decimalValue + " (PUSH_CONST_DECIMAL)");
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
            assembly.Add(";; END PUSH " + decimalValue + " (PUSH_CONST_DECIMAL)");

            return base.VisitPUSH_CONST_DECIMAL(context);
        }
    }
}
