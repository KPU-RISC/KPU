using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPU_Assembler
{
    public partial class HighLevelAssemblyVisitor<Result>
    {
        public override Result VisitMOV_IPO_R16_CONST_HEX2(HighLevelAssemblyParser.MOV_IPO_R16_CONST_HEX2Context context)
        {
            string destinationRegister = context.register_16bit().GetText();
            int offset = int.Parse(context.@int().GetText());
            string binaryValueOffset = IntToBinary(offset, 16);
            string hexValue = context.HexValue().GetText();
            string binaryValue = HexToBinary(hexValue);

            // 1. Adjust the memory address for the STORE opcode
            assembly.Add(";; BEGIN MOV " + destinationRegister + ", " + hexValue + "h (MOV_IPO_R16_CONST_HEX2)");
            assembly.AddRange(GenerateMnemonics_MOV8("MOV8 XH, \"" + binaryValueOffset.Substring(0, 8) + "\""));
            assembly.AddRange(GenerateMnemonics_MOV8("MOV8 XL, \"" + binaryValueOffset.Substring(8, 8) + "\""));
            assembly.Add("MOV16 J, X");
            assembly.Add("MOV16 X, " + destinationRegister);
            assembly.Add("16BIT_ADDER");
            assembly.Add("MOV16 M, X");

            // 2. Move the specified decimal value into register XL and store it
            assembly.AddRange(GenerateMnemonics_MOV8("MOV8 XL, \"" + binaryValue + "\""));
            assembly.Add("STORE XL");

            assembly.Add(";; END MOV " + destinationRegister + ", " + hexValue + "h (MOV_IPO_R16_CONST_HEX2)");
            return base.VisitMOV_IPO_R16_CONST_HEX2(context);
        }
    }
}
