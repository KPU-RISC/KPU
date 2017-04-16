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
        /// MOV [SP + 1], 3
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Result VisitMOV_IPO_R16_CONST_DECIMAL(HighLevelAssemblyParser.MOV_IPO_R16_CONST_DECIMALContext context)
        {
            string destinationRegister = context.register_16bit().GetText();
            int offset = int.Parse(context.@int(0).GetText());
            string binaryValueOffset = IntToBinary(offset, 16);
            int decimalValue = int.Parse(context.@int(1).GetText());
            string binaryValue = IntToBinary(decimalValue, 8);

            // 1. Adjust the memory address for the STORE opcode
            assembly.Add(";; BEGIN MOV " + destinationRegister + ", " + decimalValue + " (MOV_IPO_R16_CONST_DECIMAL)");
            assembly.AddRange(GenerateMnemonics_MOV8("MOV8 XH, \"" + binaryValueOffset.Substring(0, 8) + "\""));
            assembly.AddRange(GenerateMnemonics_MOV8("MOV8 XL, \"" + binaryValueOffset.Substring(8, 8) + "\""));
            assembly.Add("MOV16 J, X");
            assembly.Add("MOV16 X, " + destinationRegister);
            assembly.Add("16BIT_ADDER");
            assembly.Add("MOV16 M, X");

            // 2. Move the specified decimal value into register XL and store it
            assembly.AddRange(GenerateMnemonics_MOV8("MOV8 XL, \"" + binaryValue + "\""));
            assembly.Add("STORE XL");
            assembly.Add(";; END MOV " + destinationRegister + ", " + decimalValue + " (MOV_IPO_R16_CONST_DECIMAL)");

            return base.VisitMOV_IPO_R16_CONST_DECIMAL(context);
        }
    }
}
