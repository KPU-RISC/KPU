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
        /// MOV [SP], 10101010b
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Result VisitMOV_I_R16_CONST_BINARY(HighLevelAssemblyParser.MOV_I_R16_CONST_BINARYContext context)
        {
            string destinationRegister = context.register_16bit().GetText();
            string binaryValue = context.EightBitBinaryValue().GetText().Substring(0, 8);

            // Add the assembly opcode
            assembly.Add(";; BEGIN MOV [" + destinationRegister + "], " + binaryValue + "b (MOV_I_R16_CONST_BINARY)");
            assembly.Add("MOV16 M, " + destinationRegister);
            assembly.AddRange(GenerateMnemonics_MOV8("MOV8 XL, \"" + binaryValue + "\""));
            assembly.Add("STORE XL");
            assembly.Add(";; END MOV [" + destinationRegister + "], " + binaryValue + "b (MOV_I_R16_CONST_BINARY)");

            return base.VisitMOV_I_R16_CONST_BINARY(context);
        }
    }
}
