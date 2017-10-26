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
        /// MOV [SP], ABh
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Result VisitMOV_I_R16_CONST_HEX2(HighLevelAssemblyParser.MOV_I_R16_CONST_HEX2Context context)
        {
            string destinationRegister = context.register_16bit().GetText();
            string hexValue = context.HexValue().GetText();
            string binaryValue = HexToBinary(hexValue);

            // Add the assembly opcode
            assembly.Add(";; BEGIN MOV [" + destinationRegister + "], " + hexValue + "h (MOV_I_R16_CONST_HEX2)");
            assembly.Add("MOV16 M, " + destinationRegister);
            assembly.AddRange(GenerateMnemonics_MOV8("MOV8 XL, \"" + binaryValue + "\""));
            assembly.Add("STORE XL");
            assembly.Add(";; END MOV [" + destinationRegister + "], " + hexValue + "h (MOV_I_R16_CONST_HEX2)");

            return base.VisitMOV_I_R16_CONST_HEX2(context);
        }
    }
}
