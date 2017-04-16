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
        /// MOV [SP], D
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Result VisitMOV_I_R16_R8(HighLevelAssemblyParser.MOV_I_R16_R8Context context)
        {
            string sourceRegister = context.register_8bit().GetText();
            string destinationRegister = context.register_16bit().GetText();

            // Add the assembly opcode
            assembly.Add(";; BEGIN MOV [" + destinationRegister + "], " + sourceRegister + " (MOV_I_R16_R8)");
            assembly.Add("MOV16 M, " + destinationRegister);
            assembly.Add("STORE " + sourceRegister);
            assembly.Add(";; END MOV [" + destinationRegister + "], " + sourceRegister + " (MOV_I_R16_R8)");

            return base.VisitMOV_I_R16_R8(context);
        }
    }
}
