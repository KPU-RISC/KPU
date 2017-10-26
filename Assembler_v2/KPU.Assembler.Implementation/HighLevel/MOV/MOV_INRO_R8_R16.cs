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
        /// MOV D, [SP - G]
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Result VisitMOV_INRO_R8_R16(HighLevelAssemblyParser.MOV_INRO_R8_R16Context context)
        {
            string sourceRegister = context.register_16bit().GetText();
            string destinationRegister = context.register_8bit(0).GetText();
            string offsetRegister = context.register_8bit(1).GetText();
            
            // Move the register value on which the offset is based into register "X"
            assembly.Add(";; BEGIN MOV + " + destinationRegister + ", [" + sourceRegister + " - " + offsetRegister + "] (MOV_INRO_R8_16)");
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
            assembly.Add("MOV16 X, " + sourceRegister);
            assembly.Add("16BIT_ADDER");

            // Move the calculated memory address to the register "M"
            // and perform the store operation with the source register
            assembly.Add("MOV16 M, X");
            assembly.Add("LOAD " + destinationRegister);
            assembly.Add(";; END MOV + " + destinationRegister + ", [" + sourceRegister + " - " + offsetRegister + "] (MOV_INRO_R8_16)");

            return base.VisitMOV_INRO_R8_R16(context);
        }
    }
}
