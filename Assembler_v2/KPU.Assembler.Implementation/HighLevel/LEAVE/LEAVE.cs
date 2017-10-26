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
        /// LEAVE
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Result VisitLEAVE(HighLevelAssemblyParser.LEAVEContext context)
        {
            assembly.Add(";; BEGIN LEAVE");
            assembly.Add("MOV16 SP, BP");
            assembly.AddRange(GenerateMnemonics_POP_R16("BP"));
            assembly.Add(";; END LEAVE");

            return base.VisitLEAVE(context);
        }
    }
}
