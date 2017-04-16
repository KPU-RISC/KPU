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
        /// OUT C
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Result VisitOUT(HighLevelAssemblyParser.OUTContext context)
        {
            assembly.Add("OUT " + context.out_port_8bit().GetText());
            return base.VisitOUT(context);
        }
    }
}
