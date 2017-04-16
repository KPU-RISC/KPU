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
        /// PUSH SP
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Result VisitPUSH_R16(HighLevelAssemblyParser.PUSH_R16Context context)
        {
            string sourceRegister = context.register_16bit().GetText();

            // Generate the mnemonics for the PUSH instruction
            assembly.Add(";; BEGIN PUSH " + sourceRegister + " (PUSH_R16)");
            assembly.AddRange(GenerateMnemonics_PUSH_R16(sourceRegister));
            assembly.Add(";; END PUSH " + sourceRegister + " (PUSH_R16)");

            return base.VisitPUSH_R16(context);
        }

        private List<string> GenerateMnemonics_PUSH_R16(string SourceRegister)
        {
            List<string> mnemonics = new List<string>();

            // 1. Set the register "XL" to "11111111"
            mnemonics.Add("SAVE_FLAGS");
            mnemonics.AddRange(GenerateMnemonics_MOV8("MOV8 XL, \"11111111\""));
            
            // 2. Set the register "XH" to "11111111"
            mnemonics.AddRange(GenerateMnemonics_MOV8("MOV8 XH, \"11111111\""));
            
            // 3. Decrement the stack pointer by 1
            mnemonics.Add("MOV16 J, X");
            mnemonics.Add("MOV16 X, SP");
            mnemonics.Add("16BIT_ADDER");
            mnemonics.Add("MOV16 SP, X");

            // 4. Store the value of the specified register onto the stack
            mnemonics.Add("MOV16 M, SP");
            mnemonics.Add("MOV16 X, " + SourceRegister);
            mnemonics.Add("STORE XL"); // Store the 1st 8 bits onto the stack

            // 5. Set the register "XL" to "11111111"
            mnemonics.AddRange(GenerateMnemonics_MOV8("MOV8 XL, \"11111111\""));
            
            // 6. Set the register "XH" to "11111111"
            mnemonics.AddRange(GenerateMnemonics_MOV8("MOV8 XH, \"11111111\""));
            
            // 7. Decrement the stack pointer by 1
            mnemonics.Add("MOV16 J, X");
            mnemonics.Add("MOV16 X, SP");
            mnemonics.Add("16BIT_ADDER");
            mnemonics.Add("MOV16 SP, X");

            // 8. Store the value of the specified register onto the stack
            mnemonics.Add("MOV16 M, SP");
            mnemonics.Add("MOV16 X, " + SourceRegister);
            mnemonics.Add("STORE XH"); // Store the 2nd 8 bits onto the stack
            mnemonics.Add("RESTORE_FLAGS");

            return mnemonics;
        }
    }
}
