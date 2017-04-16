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
        /// NOP
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Result VisitNOP(HighLevelAssemblyParser.NOPContext context)
        {
            assembly.Add("NOP");

            return base.VisitNOP(context);
        }
    }
}
