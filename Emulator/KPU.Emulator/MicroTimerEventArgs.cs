using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPU.Emulator
{
    public class MicroTimerEventArgs : EventArgs
    {
        // Simple counter, number times timed event (callback function) executed
        public int TimerCount { get; private set; }

        // Time when timed event was called since timer started
        public long ElapsedMicroseconds { get; private set; }

        // How late the timer was compared to when it should have been called
        public long TimerLateBy { get; private set; }

        // Time it took to execute previous call to callback function (OnTimedEvent)
        public long CallbackFunctionExecutionTime { get; private set; }

        public MicroTimerEventArgs(int timerCount,
                                   long elapsedMicroseconds,
                                   long timerLateBy,
                                   long callbackFunctionExecutionTime)
        {
            TimerCount = timerCount;
            ElapsedMicroseconds = elapsedMicroseconds;
            TimerLateBy = timerLateBy;
            CallbackFunctionExecutionTime = callbackFunctionExecutionTime;
        }

    }
}
