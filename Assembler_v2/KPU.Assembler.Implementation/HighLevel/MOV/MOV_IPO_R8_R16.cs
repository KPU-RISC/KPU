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
        /// MOV D, [SP + 1]
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Result VisitMOV_IPO_R8_R16(HighLevelAssemblyParser.MOV_IPO_R8_R16Context context)
        {
            string sourceRegister = context.register_16bit().GetText();
            string destinationRegister = context.register_8bit().GetText();
            int offset = int.Parse(context.@int().GetText());
            string bitValue = IntToBinary(offset, 16);

            // Add the assembly opcode
            assembly.Add(";; BEGIN MOV " + destinationRegister + ", [" + sourceRegister + " + " + offset.ToString() + "] (MOV_IPO_R8_16)");
            assembly.AddRange(GenerateMnemonics_MOV8("MOV8 XH, \"" + bitValue.Substring(0, 8) + "\""));
            assembly.AddRange(GenerateMnemonics_MOV8("MOV8 XL, \"" + bitValue.Substring(8, 8) + "\""));
            assembly.Add("MOV16 J, X");
            assembly.Add("MOV16 X, " + sourceRegister);
            assembly.Add("16BIT_ADDER");
            assembly.Add("MOV16 M, X");
            assembly.Add("LOAD " + destinationRegister);
            assembly.Add(";; END MOV " + destinationRegister + ", [" + sourceRegister + " + " + offset.ToString() + "] (MOV_IPO_R8_16)");

            return base.VisitMOV_IPO_R8_R16(context);
        }
    }
}
