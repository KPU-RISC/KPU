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
        /// MOV [SP - G], 3
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Result VisitMOV_INRO_R16_CONST_DECIMAL(HighLevelAssemblyParser.MOV_INRO_R16_CONST_DECIMALContext context)
        {
            string destinationRegister = context.register_16bit().GetText();
            string offsetRegister = context.register_8bit().GetText();
            int decimalValue = int.Parse(context.@int().GetText());
            string binaryValue = IntToBinary(decimalValue, 8);

            // Move the register value on which the offset is based into register "X"
            assembly.Add(";; BEGIN MOV [" + destinationRegister + " - " + offsetRegister + "], " + decimalValue + " (MOV_INRO_R16_CONST_DECIMAL)");
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
            assembly.AddRange(GenerateMnemonics_MOV8("MOV8 XL, \"" + binaryValue + "\""));
            assembly.Add("STORE XL");
            assembly.Add(";; END MOV [" + destinationRegister + " - " + offsetRegister + "], " + decimalValue + " (MOV_INRO_R16_CONST_DECIMAL)");

            return base.VisitMOV_INRO_R16_CONST_DECIMAL(context);
        }
    }
}
