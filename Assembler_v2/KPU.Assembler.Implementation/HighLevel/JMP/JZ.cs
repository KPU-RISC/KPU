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
        /// JZ :JUMPLABEL
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Result VisitJZ(HighLevelAssemblyParser.JZContext context)
        {
            string jumpLabel = context.JumpLabel().GetText();

            // Save the flags register
            assembly.Add(";; BEGIN JZ " + jumpLabel);
            assembly.Add("SAVE_FLAGS");

            // Add the assembly for the lower 8 bits of the destination jump address
            // MOV8 XL, "11111111" 
            assembly.Add("SET A, \"1111\"" + jumpLabel + "_LN1");
            assembly.Add("SET B, \"1111\"" + jumpLabel + "_LN2");
            assembly.Add("MOV8");
            assembly.Add("MOV_ALU_OUT XL");
            
            // Add the assembly for the upper 8 bits of the destination jump address
            // MOV8 XH, "11111111"
            assembly.Add("SET A, \"1111\"" + jumpLabel + "_HN1");
            assembly.Add("SET B, \"1111\"" + jumpLabel + "_HN2");
            assembly.Add("MOV8");
            assembly.Add("MOV_ALU_OUT XH");
            
            // MOV16 J, X
            assembly.Add("MOV16 J, X");

            // Restore the flags register
            assembly.Add("RESTORE_FLAGS");

            // JZ "DestinationLabel"
            assembly.Add("JZ " + jumpLabel);
            assembly.Add(";; END JZ " + jumpLabel);

            return base.VisitJZ(context);
        }
    }
}
