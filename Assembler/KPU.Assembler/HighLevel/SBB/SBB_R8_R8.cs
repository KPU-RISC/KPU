﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPU_Assembler
{
    public partial class HighLevelAssemblyVisitor<Result>
    {
        /// <summary>
        /// SBB D, E
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Result VisitSBB_R8_R8(HighLevelAssemblyParser.SBB_R8_R8Context context)
        {
            string sourceRegister = context.register_8bit(1).GetText();
            string destinationRegister = context.register_8bit(0).GetText();

            // Add the assembly opcodes
            assembly.Add(";; BEGIN SBB " + destinationRegister + ", " + sourceRegister + " (SBB_R8_R8)");
            assembly.Add("MOV_ALU_IN A, " + destinationRegister);
            assembly.Add("MOV_ALU_IN B, " + sourceRegister);
            assembly.Add("SAVE_FLAGS");
            assembly.Add("SBB");
            assembly.Add("MOV_ALU_OUT " + destinationRegister);
            assembly.Add(";; END SBB " + destinationRegister + ", " + sourceRegister + " (SBB_R8_R8)");

            return base.VisitSBB_R8_R8(context);
        }
    }
}
