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
        /// ADC
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Result VisitADC(LowLevelAssemblyParser.ADCContext context)
        {
            assembly.Add("10000111 ; ADC");

            return base.VisitADC(context);
        }
    }
}
