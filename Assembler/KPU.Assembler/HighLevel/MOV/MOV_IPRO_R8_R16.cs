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
        /// MOV D, [SP + G]
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Result VisitMOV_IPRO_R8_R16(HighLevelAssemblyParser.MOV_IPRO_R8_R16Context context)
        {
            string sourceRegister = context.register_16bit().GetText();
            string destinationRegister = context.register_8bit(0).GetText();
            string offsetRegister = context.register_8bit(1).GetText();

            // Add the assembly opcode
            assembly.Add(";; BEGIN MOV " + destinationRegister + ", [" + sourceRegister + " + " + offsetRegister + "] (MOV_IPRO_R8_R16)");
            assembly.AddRange(GenerateMnemonics_ALU("XOR XH, XH", "XOR"));
            assembly.Add("MOV XL, " + offsetRegister);
            assembly.Add("MOV16 J, X");
            assembly.Add("MOV16 X, " + sourceRegister);
            assembly.Add("16BIT_ADDER");
            assembly.Add("MOV16 M, X");
            assembly.Add("LOAD " + destinationRegister);
            assembly.Add(";; END MOV " + destinationRegister + ", [" + sourceRegister + " + " + offsetRegister + "] (MOV_IPRO_R8_R16)");

            return base.VisitMOV_IPRO_R8_R16(context);
        }
    }
}
