using System;

namespace gorilla.infrastructure.threading
{
    public interface ITimerFactory
    {
        System.Timers.Timer create_for(TimeSpan span);
    }
}