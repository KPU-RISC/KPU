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
        /// PUSH D
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Result VisitPUSH_R8(HighLevelAssemblyParser.PUSH_R8Context context)
        {
            string sourceRegister = context.register_8bit().GetText();

            assembly.Add(";; BEGIN PUSH " + sourceRegister + " (PUSH_R8)");
            assembly.AddRange(GenerateMnemonics_PUSH_R8(sourceRegister));
            assembly.Add(";; END PUSH " + sourceRegister + " (PUSH_R8)");

            return base.VisitPUSH_R8(context);
        }

        private List<string> GenerateMnemonics_PUSH_R8(string SourceRegister)
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
            mnemonics.Add("STORE " + SourceRegister);
            mnemonics.Add("RESTORE_FLAGS");

            return mnemonics;
        }
    }
}
