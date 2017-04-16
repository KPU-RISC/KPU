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
        ///  ENTER 3
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Result VisitENTER(HighLevelAssemblyParser.ENTERContext context)
        {
            int integer = int.Parse(context.@int().GetText());
            string bitValue = IntToBinary(integer, 16);

            // 1. Push the BP register onto the stack
            assembly.Add(";; BEGIN ENTER " + context.@int().GetText());
            assembly.AddRange(GenerateMnemonics_PUSH_R16("BP"));

            // 2. Move the SP into the BP
            assembly.Add("MOV16 BP, SP");

            // 3.1. Move the negative offset values into register "X"
            assembly.AddRange(GenerateMnemonics_MOV8("MOV8 XH, \"" + bitValue.Substring(0, 8) + "\""));
            assembly.AddRange(GenerateMnemonics_MOV8("MOV8 XL, \"" + bitValue.Substring(8, 8) + "\""));

            // 3.2. Negate the content in register "XH" and "XL"
            assembly.AddRange(GenerateMnemonics_ALU_OneOperant("NOT XH", "NOT"));
            assembly.AddRange(GenerateMnemonics_ALU_OneOperant("NOT XL", "NOT"));

            // 3.3. Add 1 to the negated offset value in register "X"
            assembly.Add("MOV16 J, X");
            assembly.AddRange(GenerateMnemonics_MOV8("MOV8 XH, \"00000000\""));
            assembly.AddRange(GenerateMnemonics_MOV8("MOV8 XL, \"00000001\""));
            assembly.Add("16BIT_ADDER");

            // 3.4. Add the negated offset + 1 to the destination register
            assembly.Add("MOV16 J, X");
            assembly.Add("MOV16 X, SP");
            assembly.Add("16BIT_ADDER");

            // 3.5. Move the calculated memory address back to the register "SP"
            assembly.Add("MOV16 SP, X");
            assembly.Add(";; END ENTER " + context.@int().GetText());

            return base.VisitENTER(context);
        }
    }
}
