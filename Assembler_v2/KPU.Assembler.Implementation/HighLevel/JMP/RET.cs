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
        /// RET
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Result VisitRET(HighLevelAssemblyParser.RETContext context)
        {
            // 1. Load the bits 8 - 15 from the stack into the register XH, 
            // and cache it in register M
            assembly.Add("MOV16 M, SP");
            assembly.Add("LOAD XH");
            assembly.Add("MOV16 M, X");

            // 2. Set the register "XL" to "00000001"
            assembly.AddRange(GenerateMnemonics_MOV8("MOV8 XL, \"00000001\""));
            
            // 3. Set the register "XH" to "00000000"
            assembly.AddRange(GenerateMnemonics_MOV8("MOV8 XH, \"00000000\""));
            
            // 4. Increment the stack pointer
            assembly.Add("MOV16 J, X");
            assembly.Add("MOV16 X, SP");
            assembly.Add("16BIT_ADDER");
            assembly.Add("MOV16 SP, X");

            // 5. Load the bits 0 - 7 from the stack into the register XL
            assembly.Add("MOV16 X, M");
            assembly.Add("MOV16 M, SP");
            assembly.Add("LOAD XL");
            assembly.Add("MOV16 M, X");

            // 6. Set the register "XL" to "00000001"
            assembly.AddRange(GenerateMnemonics_MOV8("MOV8 XL, \"00000001\""));
            
            // 7. Set the register "XH" to "00000000"
            assembly.AddRange(GenerateMnemonics_MOV8("MOV8 XH, \"00000000\""));
            
            // 8. Increment the stack pointer
            assembly.Add("MOV16 J, X");
            assembly.Add("MOV16 X, SP");
            assembly.Add("16BIT_ADDER");
            assembly.Add("MOV16 SP, X");

            // 9. Transfer the POPed PC into the PC register to
            // jump back to the callee...
            assembly.Add("MOV16 PC, M");
            assembly.Add(";; END RET");

            return base.VisitRET(context);
        }
    }
}
