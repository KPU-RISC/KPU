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
        /// NOP
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Result VisitNOP(LowLevelAssemblyParser.NOPContext context)
        {
            string opcode = "10000000 ; NOP";

            try
            {
                // Add the jump label, if available
                opcode += context.JumpLabel().GetText();
            }
            catch (NullReferenceException) { }

            assembly.Add(opcode);

            return base.VisitNOP(context);
        }
    }
}
