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
        /// MOV16 SP, X
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Result VisitMOV16(HighLevelAssemblyParser.MOV16Context context)
        {
            string sourceRegister = context.register_16bit(1).GetText();
            string destinationRegister = context.register_16bit(0).GetText();

            // Add the assembly opcode
            assembly.Add(";; BEGIN MOV16 " + destinationRegister + ", " + sourceRegister + " (MOV16)");
            assembly.Add("MOV16 " + destinationRegister + ", " + sourceRegister);
            assembly.Add(";; END MOV16 " + destinationRegister + ", " + sourceRegister + " (MOV16)");

            return base.VisitMOV16(context);
        }
    }
}
