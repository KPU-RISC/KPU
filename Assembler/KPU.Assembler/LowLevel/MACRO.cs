using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPU_Assembler
{
    public partial class LowLevelAssemblyVisitor<Result> : LowLevelAssemblyBaseVisitor<Result>
    {
        public override Result VisitMACRO(LowLevelAssemblyParser.MACROContext context)
        {
            assembly.Add(context.MACRO().GetText());

            return base.VisitMACRO(context);
        }
    }
}
