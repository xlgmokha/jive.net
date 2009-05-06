using System;
using System.Timers;

namespace Gorilla.Commons.Infrastructure.Threading
{
    public interface ITimerFactory
    {
        Timer create_for(TimeSpan span);
    }

    public class TimerFactory : ITimerFactory
    {
        public Timer create_for(TimeSpan span)
        {
            if (span.Seconds > 0) {
                var milliseconds = span.Seconds*1000;
                return new Timer(milliseconds);
            }
            return new Timer(span.Ticks);
        }
    }
}