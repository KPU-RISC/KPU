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
        /// MOV D, E
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Result VisitMOV_R8_R8(HighLevelAssemblyParser.MOV_R8_R8Context context)
        {
            string sourceRegister = context.register_8bit(1).GetText();
            string destinationRegister = context.register_8bit(0).GetText();

            // Add the assembly opcode
            assembly.Add(";; BEGIN MOV " + destinationRegister + ", " + sourceRegister + " (MOV_R8_R8)");
            assembly.Add("MOV " + destinationRegister + ", " + sourceRegister);
            assembly.Add(";; END MOV " + destinationRegister + ", " + sourceRegister + " (MOV_R8_R8)");

            return base.VisitMOV_R8_R8(context);
        }
    }
}
