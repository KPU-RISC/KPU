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
        /// MOV [SP + 1], D
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Result VisitMOV_IPO_R16_R8(HighLevelAssemblyParser.MOV_IPO_R16_R8Context context)
        {
            string sourceRegister = context.register_8bit().GetText();
            string destinationRegister = context.register_16bit().GetText();
            int offset = int.Parse(context.@int().GetText());
            string bitValue = IntToBinary(offset, 16);

            // Add the assembly opcode
            assembly.Add(";; BEGIN MOV [" + destinationRegister + " + " + offset.ToString() + "], " + sourceRegister + " (MOV_IPO_R16_R8)");
            assembly.AddRange(GenerateMnemonics_MOV8("MOV8 XH, \"" + bitValue.Substring(0, 8) + "\""));
            assembly.AddRange(GenerateMnemonics_MOV8("MOV8 XL, \"" + bitValue.Substring(8, 8) + "\""));
            assembly.Add("MOV16 J, X");
            assembly.Add("MOV16 X, " + destinationRegister);
            assembly.Add("16BIT_ADDER");
            assembly.Add("MOV16 M, X");
            assembly.Add("STORE " + sourceRegister);
            assembly.Add(";; END MOV [" + destinationRegister + " + " + offset.ToString() + "], " + sourceRegister + " (MOV_IPO_R16_R8)");

            return base.VisitMOV_IPO_R16_R8(context);
        }
    }
}
