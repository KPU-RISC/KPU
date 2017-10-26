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
        /// POPF
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Result VisitPOPF(HighLevelAssemblyParser.POPFContext context)
        {
            assembly.Add(";; BEGIN POPF");
            assembly.AddRange(GenerateMnemonics_POPF());
            assembly.Add(";; END POPF");

            return base.VisitPOPF(context);
        }

        public List<string> GenerateMnemonics_POPF()
        {
            List<string> mnemonics = new List<string>();

            // 1. Load the flags into the "FlagsInBuffer"
            // This buffering is necessary, because the following Increment Operation on the Stack Pointer
            // will change the Flags Content that is finally transferred from the "FlagsInBuffer" to the Flags register.
            mnemonics.Add("MOV16 M, SP");
            mnemonics.Add("LOAD_FLAGS");

            // 2. Set the register "XL" to "00000001"
            mnemonics.AddRange(GenerateMnemonics_MOV8("MOV8 XL, \"00000001\""));
            
            // 3. Set the register "XH" to "00000000"
            mnemonics.AddRange(GenerateMnemonics_MOV8("MOV8 XH, \"00000000\""));
            
            // 4. Increment the stack pointer
            mnemonics.Add("MOV16 J, X");
            mnemonics.Add("MOV16 X, SP");
            mnemonics.Add("16BIT_ADDER");
            mnemonics.Add("MOV16 SP, X");

            // 5. Move the content from the FlagsInBuffer" to the Flags register
            mnemonics.Add("INBUFFER_TO_FLAGS");

            return mnemonics;
        }
    }
}
