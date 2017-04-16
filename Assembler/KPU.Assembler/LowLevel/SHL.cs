﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPU_Assembler
{
    public partial class LowLevelAssemblyVisitor<Result> : LowLevelAssemblyBaseVisitor<Result>
    {
        /// <summary>
        /// SHL
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Result VisitSHL(LowLevelAssemblyParser.SHLContext context)
        {
            assembly.Add("10000110 ; SHL");

            return base.VisitSHL(context);
        }
    }
}
