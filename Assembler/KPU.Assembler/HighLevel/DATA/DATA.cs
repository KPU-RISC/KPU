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
        /// Adds the Data Section.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Result VisitDATA(HighLevelAssemblyParser.DATAContext context)
        {
            string memoryAddress = context.SixteenBitBinaryValue().GetText().Substring(0, 16);
            string dataValue = context.EightBitBinaryValue().GetText().Substring(0, 8);

            assembly.Add("DATA " + memoryAddress + "b, " + dataValue + "b");

            return base.VisitDATA(context);
        }
    }
}
