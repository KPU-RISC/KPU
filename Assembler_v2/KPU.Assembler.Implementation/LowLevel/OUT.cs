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
        /// OUT C
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Result VisitOUT(LowLevelAssemblyParser.OUTContext context)
        {
            string outputPort = context.out_port_8bit().GetText();
            string opcode = "1100111";

            if (outputPort == "C")
                opcode += "0";
            else if (outputPort == "D")
                opcode += "1";
            else
                throw new Exception("Invalid Output Port!");

            opcode += " ; OUT ";
            opcode += outputPort;
            assembly.Add(opcode);
            
            return base.VisitOUT(context);
        }
    }
}
