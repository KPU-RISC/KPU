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
        /// IN A
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Result VisitIN(LowLevelAssemblyParser.INContext context)
        {
            string inputPort = context.port_8bit().GetText();
            string opcode = "1100110";

            if (inputPort == "A")
                opcode += "0";
            else if (inputPort == "B")
                opcode += "1";
            else
                throw new Exception("Invalid Input Port!");

            opcode += " ; IN " + inputPort;
            assembly.Add(opcode);

            return base.VisitIN(context);
        }
    }
}
