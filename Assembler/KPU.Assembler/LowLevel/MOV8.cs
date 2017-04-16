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
        /// MOV8
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Result VisitMOV8(LowLevelAssemblyParser.MOV8Context context)
        {
            assembly.Add("10001111 ; MOV8");

            return base.VisitMOV8(context);
        }
    }
}
