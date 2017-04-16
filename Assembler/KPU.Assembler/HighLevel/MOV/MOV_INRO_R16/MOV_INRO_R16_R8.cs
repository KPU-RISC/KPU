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
        /// MOV [SP - G], D
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Result VisitMOV_INRO_R16_R8(HighLevelAssemblyParser.MOV_INRO_R16_R8Context context)
        {
            string sourceRegister = context.register_8bit(1).GetText();
            string destinationRegister = context.register_16bit().GetText();
            string offsetRegister = context.register_8bit(0).GetText();

            // Move the register value on which the offset is based into register "X"
            assembly.Add(";; BEGIN MOV [" + destinationRegister + " - " + offsetRegister + "], " + sourceRegister + " (MOV_INRO_R16_R8)");
            assembly.AddRange(GenerateMnemonics_ALU("XOR XH, XH", "XOR"));
            assembly.Add("MOV XL, " + offsetRegister);

            // Negate the content in register "XH" and "XL"
            assembly.AddRange(GenerateMnemonics_ALU_OneOperant("NOT XH", "NOT"));
            assembly.AddRange(GenerateMnemonics_ALU_OneOperant("NOT XL", "NOT"));

            // Add 1 to the negated offset value in register "X"
            assembly.Add("MOV16 J, X");
            assembly.AddRange(GenerateMnemonics_MOV8("MOV8 XH, \"00000000\""));
            assembly.AddRange(GenerateMnemonics_MOV8("MOV8 XL, \"00000001\""));
            assembly.Add("16BIT_ADDER");

            // Add the negated offset + 1 to the destination register
            assembly.Add("MOV16 J, X");
            assembly.Add("MOV16 X, " + destinationRegister);
            assembly.Add("16BIT_ADDER");

            // Move the calculated memory address to the register "M"
            // and perform the store operation with the source register
            assembly.Add("MOV16 M, X");
            assembly.Add("STORE " + sourceRegister);
            assembly.Add(";; END MOV [" + destinationRegister + " - " + offsetRegister + "], " + sourceRegister + " (MOV_INRO_R16_R8)");

            return base.VisitMOV_INRO_R16_R8(context);
        }
    }
}
