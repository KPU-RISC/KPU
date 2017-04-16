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
        /// MOV D, "10101010"
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Result VisitMOV_CONST_BINARY(HighLevelAssemblyParser.MOV_CONST_BINARYContext context)
        {
            string destinationRegister = context.register_8bit().GetText();
            string binaryValue = context.EightBitBinaryValue().GetText().Substring(0, 8);

            // Add the assembly opcode
            assembly.Add(";; BEGIN MOV " + destinationRegister + ", " + binaryValue + "b (MOV_CONST_BINARY)");
            assembly.AddRange(GenerateMnemonics_MOV8("MOV8 " + destinationRegister + ", \"" + binaryValue + "\""));
            assembly.Add(";; END MOV " + destinationRegister + ", " + binaryValue + "b (MOV_CONST_BINARY)");

            return base.VisitMOV_CONST_BINARY(context);
        }
    }
}
