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
        /// OUTB D
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Result VisitOUTB(HighLevelAssemblyParser.OUTBContext context)
        {
            // Add the assembly opcode
            assembly.Add(";; BEGIN OUTB " + context.register_8bit().GetText());
            assembly.Add("MOV XL, " + context.register_8bit().GetText());
            assembly.Add("OUT C");
            assembly.AddRange(GenerateMnemonics_MOV8("MOV8 XL, \"00000010\""));
            assembly.Add("OUT D");
            assembly.AddRange(GenerateMnemonics_MOV8("MOV8 XL, \"00000000\""));
            assembly.Add("OUT D");
            assembly.Add(";; END OUTB " + context.register_8bit().GetText());

            return base.VisitOUTB(context);
        }
    }
}
