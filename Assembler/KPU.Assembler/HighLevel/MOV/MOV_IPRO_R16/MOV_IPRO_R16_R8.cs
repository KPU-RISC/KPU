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
        /// MOV [SP + G], D
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Result VisitMOV_IPRO_R16_R8(HighLevelAssemblyParser.MOV_IPRO_R16_R8Context context)
        {
            string sourceRegister = context.register_8bit(1).GetText();
            string destinationRegister = context.register_16bit().GetText();
            string offsetRegister = context.register_8bit(0).GetText();

            // Add the assembly opcodes
            assembly.Add(";; BEGIN MOV + [" + destinationRegister + " + " + offsetRegister + "], " + sourceRegister + " (MOV_IPRO_R16_R8)");
            assembly.AddRange(GenerateMnemonics_ALU("XOR XH, XH", "XOR"));
            assembly.Add("MOV XL, " + offsetRegister);
            assembly.Add("MOV16 J, X");
            assembly.Add("MOV16 X, " + destinationRegister);
            assembly.Add("16BIT_ADDER");
            assembly.Add("MOV16 M, X");
            assembly.Add("STORE " + sourceRegister);
            assembly.Add(";; END MOV + [" + destinationRegister + " + " + offsetRegister + "], " + sourceRegister + " (MOV_IPRO_R16_R8)");

            return base.VisitMOV_IPRO_R16_R8(context);
        }
    }
}
