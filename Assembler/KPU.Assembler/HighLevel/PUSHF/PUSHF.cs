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
        /// PUSHF
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Result VisitPUSHF(HighLevelAssemblyParser.PUSHFContext context)
        {
            // 1. Store the flags in the "FlagsOutBuffer"
            assembly.Add(";; BEGIN PUSHF");
            assembly.AddRange(GenerateMnemonics_PUSHF());
            assembly.Add(";; END PUSHF");

            return base.VisitPUSHF(context);
        }

        private List<string> GenerateMnemonics_PUSHF()
        {
            List<string> mnemonics = new List<string>();

            // 1. Store the flags in the "FlagsOutBuffer"
            // This buffering is necessary, because the following Decrement Operation on the Stack Pointer
            // will change the Flags Content that is finally stored on the Stack through the STORE_FLAGS opcode.
            mnemonics.Add("FLAGS_TO_OUTBUFFER");

            // 2. Set the register "XL" to "11111111"
            mnemonics.AddRange(GenerateMnemonics_MOV8("MOV8 XL, \"11111111\""));
            
            // 3. Set the register "XH" to "11111111"
            mnemonics.AddRange(GenerateMnemonics_MOV8("MOV8 XH, \"11111111\""));
            
            // 4. Decrement the stack pointer by 1
            mnemonics.Add("MOV16 J, X");
            mnemonics.Add("MOV16 X, SP");
            mnemonics.Add("16BIT_ADDER");
            mnemonics.Add("MOV16 SP, X");

            // 5. Store the flags onto the stack
            mnemonics.Add("MOV16 M, SP");
            mnemonics.Add("STORE_FLAGS");

            return mnemonics;
        }
    }
}
