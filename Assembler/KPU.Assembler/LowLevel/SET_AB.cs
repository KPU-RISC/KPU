using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPU_Assembler
{
    public partial class LowLevelAssemblyVisitor<Result> : LowLevelAssemblyBaseVisitor<Result>
    {
        public override Result VisitSET(LowLevelAssemblyParser.SETContext context)
        {
            string register = context.register_ab().GetText();
            string binaryValue = context.FourBitBinaryValue().GetText();
            
            string opcode = "111";
            opcode += GetRegisterOpCode_ALU(register);
            opcode += binaryValue;
            opcode += " ; SET " + register + ", \"" + binaryValue + "\"";

            try
            {
                opcode += context.JumpLabel().GetText();
                opcode += context.@int().GetText();
            }
            catch (NullReferenceException) { }
    
            assembly.Add(opcode);

            return base.VisitSET(context);
        }
    }
}
