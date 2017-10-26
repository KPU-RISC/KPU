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
        /// MOV D, [SP]
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Result VisitMOV_I_R8_R16(HighLevelAssemblyParser.MOV_I_R8_R16Context context)
        {
            string sourceRegister = context.register_16bit().GetText();
            string destinationRegister = context.register_8bit().GetText();

            // Add the assembly opcodes
            assembly.Add(";; BEGIN MOV " + destinationRegister + ", [" + sourceRegister + "] (MOV_I_R8_16)");
            assembly.Add("MOV16 M, " + sourceRegister);
            assembly.Add("LOAD " + destinationRegister);
            assembly.Add(";; END MOV " + destinationRegister + ", [" + sourceRegister + "] (MOV_I_R8_16)");

            return base.VisitMOV_I_R8_R16(context);
        }
    }
}
