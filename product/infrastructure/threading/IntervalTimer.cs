using System;
using System.Collections.Generic;

namespace gorilla.infrastructure.threading
{
    public class IntervalTimer : Timer
    {
        readonly ITimerFactory factory;
        readonly IDictionary<TimerClient, System.Timers.Timer> timers;

        public IntervalTimer() : this(new TimerFactory())
        {
        }

        public IntervalTimer(ITimerFactory factory)
        {
            this.factory = factory;
            timers = new Dictionary<TimerClient, System.Timers.Timer>();
        }

        public void start_notifying(TimerClient client_to_be_notified, TimeSpan span)
        {
            stop_notifying(client_to_be_notified);

            var timer = factory.create_for(span);
            timer.Elapsed += (o, e) =>
            {
                client_to_be_notified.notify();
            };
            timer.Start();
            timers[client_to_be_notified] = timer;
        }

        public void stop_notifying(TimerClient client_to_stop_notifying)
        {
            if (!timers.ContainsKey(client_to_stop_notifying)) return;
            timers[client_to_stop_notifying].Stop();
            timers[client_to_stop_notifying].Dispose();
        }
    }
}