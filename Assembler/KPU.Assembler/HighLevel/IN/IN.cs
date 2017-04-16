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
        /// IN A
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Result VisitIN(HighLevelAssemblyParser.INContext context)
        {
            assembly.Add("IN " + context.port_8bit().GetText());
            return base.VisitIN(context);
        }
    }
}
