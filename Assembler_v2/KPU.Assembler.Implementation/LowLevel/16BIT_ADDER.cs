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
        /// 16BIT_ADDER
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Result VisitBIT16_ADDER(LowLevelAssemblyParser.BIT16_ADDERContext context)
        {
            assembly.Add("11001000 ; 16BIT_ADDER");

 	        return base.VisitBIT16_ADDER(context);
        }
    } 
}
