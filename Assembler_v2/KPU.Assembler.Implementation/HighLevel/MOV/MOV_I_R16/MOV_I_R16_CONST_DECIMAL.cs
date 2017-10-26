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
        /// MOV [SP], 3
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Result VisitMOV_I_R16_CONST_DECIMAL(HighLevelAssemblyParser.MOV_I_R16_CONST_DECIMALContext context)
        {
            string destinationRegister = context.register_16bit().GetText();
            int decimalValue = int.Parse(context.@int().GetText());
            string binaryValue = IntToBinary(decimalValue, 8);

            // Add the assembly opcode
            assembly.Add(";; BEGIN MOV [" + destinationRegister + "], " + decimalValue + " (MOV_I_R16_CONST_DECIMAL)");
            assembly.Add("MOV16 M, " + destinationRegister);
            assembly.AddRange(GenerateMnemonics_MOV8("MOV8 XL, \"" + binaryValue + "\""));
            assembly.Add("STORE XL");
            assembly.Add(";; END MOV [" + destinationRegister + "], " + decimalValue + " (MOV_I_R16_CONST_DECIMAL)");

            return base.VisitMOV_I_R16_CONST_DECIMAL(context);
        }
    }
}
