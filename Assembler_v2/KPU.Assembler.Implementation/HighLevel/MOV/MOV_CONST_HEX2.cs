using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPU_Assembler
{
    public partial class HighLevelAssemblyVisitor<Result>
    {
        public override Result VisitMOV_CONST_HEX2(HighLevelAssemblyParser.MOV_CONST_HEX2Context context)
        {
            string destinationRegister = context.register_8bit().GetText();
            string hexValue = context.HexValue().GetText();
            string binaryValue = HexToBinary(hexValue);

            // Add the assembly opcode
            assembly.Add(";; BEGIN MOV " + destinationRegister + ", " + hexValue + "h (MOV_CONST_HEX2)");
            assembly.AddRange(GenerateMnemonics_MOV8("MOV8 " + destinationRegister + ", \"" + binaryValue + "\""));
            assembly.Add(";; END MOV " + destinationRegister + ", " + hexValue + "h (MOV_CONST_HEX2)");

            return base.VisitMOV_CONST_HEX2(context);
        }
    }
}
