using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPU_Assembler
{
    public partial class LowLevelAssemblyVisitor<Result> : LowLevelAssemblyBaseVisitor<Result>
    {
        /// <summary>
        /// MOV D, E
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Result VisitMOV16(LowLevelAssemblyParser.MOV16Context context)
        {
            string destinationRegister = context.register_16bit(0).GetText();
            string sourceRegister = context.register_16bit(1).GetText();

            string opcode = "01";
            opcode += GetRegisterOpCode_GeneralPurpose_MOV16(destinationRegister);
            opcode += GetRegisterOpCode_GeneralPurpose_MOV16(sourceRegister);
            opcode += " ; MOV16 " + destinationRegister + ", " + sourceRegister;
            assembly.Add(opcode);

            return base.VisitMOV16(context);
        }
    }
}
