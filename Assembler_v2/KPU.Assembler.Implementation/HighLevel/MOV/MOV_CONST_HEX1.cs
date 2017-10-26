using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPU_Assembler
{
    public partial class HighLevelAssemblyVisitor<Result>
    {
        public override Result VisitMOV_CONST_HEX1(HighLevelAssemblyParser.MOV_CONST_HEX1Context context)
        {
            string destinationRegister = context.register_8bit().GetText();
            string hexValue = context.HexValue().GetText();
            string binaryValue = HexToBinary(hexValue);
            
            // Add the assembly opcode
            assembly.Add(";; BEGIN MOV " + destinationRegister + ", 0x" + hexValue + " (MOV_CONST_HEX1)");
            assembly.AddRange(GenerateMnemonics_MOV8("MOV8 " + destinationRegister + ", \"" + binaryValue + "\""));
            assembly.Add(";; END MOV " + destinationRegister + ", 0x" + hexValue + " (MOV_CONST_HEX1)");

            return base.VisitMOV_CONST_HEX1(context);
        }
    }
}
