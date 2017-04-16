using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPU_Assembler
{
    public partial class LowLevelAssemblyVisitor<Result> : LowLevelAssemblyBaseVisitor<Result>
    {
        public override Result VisitINT(LowLevelAssemblyParser.INTContext context)
        {
            string opcode = "11010000";
            opcode += " ; INT";
            assembly.Add(opcode);

            return base.VisitINT(context);
        }
    }
}
