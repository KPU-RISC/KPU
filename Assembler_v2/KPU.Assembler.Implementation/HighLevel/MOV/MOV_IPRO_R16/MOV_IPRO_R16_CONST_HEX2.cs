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
        /// MOV [SP + G], ABh
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Result VisitMOV_IPRO_R16_CONST_HEX2(HighLevelAssemblyParser.MOV_IPRO_R16_CONST_HEX2Context context)
        {
            string destinationRegister = context.register_16bit().GetText();
            string offsetRegister = context.register_8bit().GetText();
            string hexValue = context.HexValue().GetText();
            string binaryValue = HexToBinary(hexValue);

            // 1. Adjust the memory address for the STORE opcode
            assembly.Add(";; BEGIN MOV + [" + destinationRegister + " + " + offsetRegister + "], " + hexValue + "h (MOV_IPRO_R16_CONST_HEX2)");
            assembly.AddRange(GenerateMnemonics_ALU("XOR XH, XH", "XOR"));
            assembly.Add("MOV XL, " + offsetRegister);
            assembly.Add("MOV16 J, X");
            assembly.Add("MOV16 X, " + destinationRegister);
            assembly.Add("16BIT_ADDER");
            assembly.Add("MOV16 M, X");

            // 2. Move the specified decimal value into register XL and store it
            assembly.AddRange(GenerateMnemonics_MOV8("MOV8 XL, \"" + binaryValue + "\""));
            assembly.Add("STORE XL");
            assembly.Add(";; END MOV + [" + destinationRegister + " + " + offsetRegister + "], " + hexValue + "h (MOV_IPRO_R16_CONST_HEX2)");

            return base.VisitMOV_IPRO_R16_CONST_HEX2(context);
        }
    }
}
