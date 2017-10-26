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
        /// CALL :JUMPLABEL
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Result VisitCALL(HighLevelAssemblyParser.CALLContext context)
        {
            string jumpLabel = context.JumpLabel().GetText();

            // 1. Store the current PC in the J register and fix it
            // to point to the address *after* the JMP instruction.
            // The implementation of the CALL micro code takes 53 - 9 = 44 instructions.
            // We have to subtract 10, because there are 10 instructions before we read
            // the PC into the register X for the addition
            // But we only add 43d (00101011b) to the current PC, because when we finally
            // POP the PC during the RET opcode, the PC will be incremented to
            // point to the next (correct) instruction.

            // 1.1. Set the value of the register XL to "00101011b"
            // 4 bytes long
            assembly.Add(";; BEGIN CALL " + jumpLabel);
            assembly.AddRange(GenerateMnemonics_MOV8("MOV8 XL, \"00101011b\""));
            
            // 1.2. Set the value of the register XH to "00000000"
            // 4 bytes long
            assembly.AddRange(GenerateMnemonics_MOV8("MOV8 XH, \"00000000\""));

            // 1.3. Add the bytes to the value in the register PC
            // 4 bytes long
            assembly.Add("MOV16 J, X");
            assembly.Add("MOV16 X, PC"); // <<<<<
            assembly.Add("16BIT_ADDER");
            assembly.Add("MOV16 M, X");

            // 2. Decrement the stack pointer by 1

            // 2.1. Set the value of the register XL to "11111111"
            // 4 bytes long
            assembly.AddRange(GenerateMnemonics_MOV8("MOV8 XL, \"11111111\""));

            // 2.2. Set the value of the register XH to "11111111"
            // 4 bytes long
            assembly.AddRange(GenerateMnemonics_MOV8("MOV8 XH, \"11111111\""));

            // 2.3. Decrement the stack pointer
            // 4 bytes long
            assembly.Add("MOV16 J, X");
            assembly.Add("MOV16 X, SP");
            assembly.Add("16BIT_ADDER");
            assembly.Add("MOV16 SP, X");

            // 3. Push the 1st 8 bit of the PC onto the stack
            // 4 bytes long
            assembly.Add("MOV16 X, M");
            assembly.Add("MOV16 M, SP");
            assembly.Add("STORE XL");
            assembly.Add("MOV16 M, X");

            // 4. Decrement the stack pointer by 1

            // 4.1. Set the value of the register XL to "11111111"
            // 4 bytes long
            assembly.AddRange(GenerateMnemonics_MOV8("MOV8 XL, \"11111111\""));

            // 4.2. Set the value of the register XH to "11111111"
            // 4 bytes long
            assembly.AddRange(GenerateMnemonics_MOV8("MOV8 XH, \"11111111\""));

            // 4.3. Decrement the stack pointer
            // 4 bytes long
            assembly.Add("MOV16 J, X");
            assembly.Add("MOV16 X, SP");
            assembly.Add("16BIT_ADDER");
            assembly.Add("MOV16 SP, X");

            // 5. Push the 2nd 8 bit of the PC onto the stack
            // 3 bytes long
            assembly.Add("MOV16 X, M");
            assembly.Add("MOV16 M, SP");
            assembly.Add("STORE XH");

            // 6. Perform the actual jump to the subroutine
            // 10 bytes long
            assembly.Add("SET A, \"1111\"" + jumpLabel + "_LN1");
            assembly.Add("SET B, \"1111\"" + jumpLabel + "_LN2");
            assembly.Add("MOV8");
            assembly.Add("MOV_ALU_OUT XL");
            assembly.Add("SET A, \"1111\"" + jumpLabel + "_HN1");
            assembly.Add("SET B, \"1111\"" + jumpLabel + "_HN2");
            assembly.Add("MOV8");
            assembly.Add("MOV_ALU_OUT XH");
            assembly.Add("MOV16 J, X");
            assembly.Add("JMP " + jumpLabel);
            assembly.Add(";; END CALL " + jumpLabel);

            return base.VisitCALL(context);
        }
    }
}
