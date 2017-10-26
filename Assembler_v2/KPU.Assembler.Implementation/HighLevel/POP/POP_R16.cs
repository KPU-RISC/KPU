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
        /// POP BP
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Result VisitPOP_R16(HighLevelAssemblyParser.POP_R16Context context)
        {
            string destinationRegister = context.register_16bit().GetText();

            // Generate the mnemonics for the POP instruction
            assembly.Add(";; BEGIN POP " + destinationRegister + " (POP_R16)");
            assembly.AddRange(GenerateMnemonics_POP_R16(destinationRegister));
            assembly.Add(";; END POP " + destinationRegister + " (POP_R16)");

            return base.VisitPOP_R16(context);
        }

        private List<string> GenerateMnemonics_POP_R16(string DestinationRegister)
        {
            List<string> mnemonics = new List<string>();

            // 1. Load the value from the stack into the provided register
            mnemonics.Add("SAVE_FLAGS");
            mnemonics.Add("MOV16 M, SP");
            mnemonics.Add("LOAD XH");
            mnemonics.Add("MOV16 " + DestinationRegister + ", X");

            // 2. Set the register "XL" to "00000001"
            mnemonics.AddRange(GenerateMnemonics_MOV8("MOV8 XL, \"00000001\""));
            
            // 3. Set the register "XH" to "00000000"
            mnemonics.AddRange(GenerateMnemonics_MOV8("MOV8 XH, \"00000000\""));
            
            // 4. Increment the stack pointer
            mnemonics.Add("MOV16 J, X");
            mnemonics.Add("MOV16 X, SP");
            mnemonics.Add("16BIT_ADDER");
            mnemonics.Add("MOV16 SP, X");

            // 5. Load the value from the stack into the provided register
            mnemonics.Add("MOV16 M, SP");
            mnemonics.Add("MOV16 X, " + DestinationRegister);
            mnemonics.Add("LOAD XL");
            mnemonics.Add("MOV16 " + DestinationRegister + ", X");

            // 6. Set the register "XL" to "00000001"
            mnemonics.AddRange(GenerateMnemonics_MOV8("MOV8 XL, \"00000001\""));
            
            // 7. Set the register "XH" to "00000000"
            mnemonics.AddRange(GenerateMnemonics_MOV8("MOV8 XH, \"00000000\""));
            
            // 8. Increment the stack pointer
            mnemonics.Add("MOV16 J, X");
            mnemonics.Add("MOV16 X, SP");
            mnemonics.Add("16BIT_ADDER");
            mnemonics.Add("MOV16 SP, X");
            mnemonics.Add("RESTORE_FLAGS");

            return mnemonics;
        }
    }
}
