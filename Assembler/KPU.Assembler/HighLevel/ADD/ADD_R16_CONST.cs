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
        /// ADD SP, 3
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Result VisitADD_R16_CONST(HighLevelAssemblyParser.ADD_R16_CONSTContext context)
        {
            string destinationRegister = context.register_16bit().GetText();
            int integer = int.Parse(context.@int().GetText());
            string bitValue = IntToBinary(integer, 16);

            // Add the assembly opcode
            assembly.Add(";; BEGIN ADD " + destinationRegister + ", " + integer.ToString()+ " (ADD_R16_CONST)");
            assembly.AddRange(GenerateMnemonics_MOV8("MOV8 XH, \"" + bitValue.Substring(0, 8) + "\""));
            assembly.AddRange(GenerateMnemonics_MOV8("MOV8 XL, \"" + bitValue.Substring(8, 8) + "\""));
            assembly.Add("MOV16 J, X");
            assembly.Add("MOV16 X, " + destinationRegister);
            assembly.Add("16BIT_ADDER");
            assembly.Add("MOV16 " + destinationRegister + ", X");
            assembly.Add(";; END ADD " + destinationRegister + ", " + integer.ToString() + " (ADD_R16_CONST)");

            return base.VisitADD_R16_CONST(context);
        }
    }
}
