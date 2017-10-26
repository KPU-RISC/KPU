using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPU_Assembler
{
    public partial class LowLevelAssemblyVisitor<Result> : LowLevelAssemblyBaseVisitor<Result>
    {
        public override Result VisitDATA(LowLevelAssemblyParser.DATAContext context)
        {
            string memoryAddress = context.SixteenBitBinaryValue().GetText().Substring(0, 16);
            string dataValue = context.EightBitBinaryValue().GetText().Substring(0, 8);

            assembly.Add(dataValue + " ; DATA " + memoryAddress + "b, " + dataValue + "b");

            return base.VisitDATA(context);
        }
    }
}
