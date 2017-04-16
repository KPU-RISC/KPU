using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPU_Assembler
{
    public partial class HighLevelAssemblyVisitor<Result>
    {
        public override Result VisitMOV_CONST_DECIMAL(HighLevelAssemblyParser.MOV_CONST_DECIMALContext context)
        {
            string destinationRegister = context.register_8bit().GetText();
            int decimalValue = int.Parse(context.@int().GetText());
            string binaryValue = IntToBinary(decimalValue, 8);

            // Add the assembly opcode
            assembly.Add(";; BEGIN MOV " + destinationRegister + ", " + decimalValue + " (MOV_CONST_DECIMAL)");
            assembly.AddRange(GenerateMnemonics_MOV8("MOV8 " + destinationRegister + ", \"" + binaryValue + "\""));
            assembly.Add(";; END MOV " + destinationRegister + ", " + decimalValue + " (MOV_CONST_DECIMAL)");

            return base.VisitMOV_CONST_DECIMAL(context);
        }
    }
}