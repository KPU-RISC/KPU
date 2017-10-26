using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPU_Assembler
{
    public partial class LowLevelAssemblyVisitor<Result> : LowLevelAssemblyBaseVisitor<Result>
    {
        /// <summary>
        /// XOR
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Result VisitXOR(LowLevelAssemblyParser.XORContext context)
        {
            assembly.Add("10000001 ; XOR");

            return base.VisitXOR(context);
        }
    }
}
