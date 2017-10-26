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
        /// HLT
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Result VisitHLT(HighLevelAssemblyParser.HLTContext context)
        {
            assembly.Add("HLT");

            return base.VisitHLT(context);
        }
    }
}
