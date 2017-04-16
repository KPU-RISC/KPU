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
        /// POP D
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Result VisitPOP_R8(HighLevelAssemblyParser.POP_R8Context context)
        {
            string sourceRegister = context.register_8bit().GetText();

            // 1. Load the value from the stack into the provided register
            assembly.Add(";; BEGIN POP " + sourceRegister + " (POP_R8)");
            assembly.AddRange(GenerateMnemonics_POP_R8(sourceRegister));
            assembly.Add(";; END POP " + sourceRegister + " (POP_R8)");

            return base.VisitPOP_R8(context);
        }

        public List<string> GenerateMnemonics_POP_R8(string SourceRegister)
        {
            List<string> mnemonics = new List<string>();

            mnemonics.Add("SAVE_FLAGS");
            mnemonics.Add("MOV16 M, SP");
            mnemonics.Add("LOAD " + SourceRegister);

            // 2. Set the register "XL" to "00000001"
            mnemonics.AddRange(GenerateMnemonics_MOV8("MOV8 XL, \"00000001\""));
            
            // 3. Set the register "XH" to "00000000"
            mnemonics.AddRange(GenerateMnemonics_MOV8("MOV8 XH, \"00000000\""));
            
            // 4. Increment the stack pointer
            mnemonics.Add("MOV16 J, X");
            mnemonics.Add("MOV16 X, SP");
            mnemonics.Add("16BIT_ADDER");
            mnemonics.Add("MOV16 SP, X");
            mnemonics.Add("RESTORE_FLAGS");

            return mnemonics;
        }
    }
}
