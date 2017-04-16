using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPU_Assembler
{
    public partial class HighLevelAssemblyVisitor<Result>
    {
        public override Result VisitINT(HighLevelAssemblyParser.INTContext context)
        {
            string interruptNumber = IntToBinary(int.Parse(context.@int().GetText()), 8);
            assembly.AddRange(GenerateMnemonics_MOV8("MOV8 XL, \"" + interruptNumber + "\""));
            assembly.Add("INT " + context.@int().GetText());
            return base.VisitINT(context);
        }
    }
}
