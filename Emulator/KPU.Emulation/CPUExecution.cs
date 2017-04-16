using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPU.Emulation
{
    public enum CPUExecution
    {
        MORE_INSTRUCTIONS_AVAILABLE,
        FINISHED,
        BREAKPOINT_HIT,
        INTERRUPT,
        IN_A,
        IN_B
    }
}
