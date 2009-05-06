using System;
using System.Collections.Generic;
using System.Timers;

namespace Gorilla.Commons.Infrastructure.Threading
{
    public interface ITimer
    {
        void start_notifying(ITimerClient client_to_be_notified, TimeSpan span);
        void stop_notifying(ITimerClient client_to_stop_notifying);
    }

    public class IntervalTimer : ITimer
    {
        readonly ITimerFactory factory;
        readonly IDictionary<ITimerClient, Timer> timers;

        public IntervalTimer() : this(new TimerFactory())
        {
        }

        public IntervalTimer(ITimerFactory factory)
        {
            this.factory = factory;
            timers = new Dictionary<ITimerClient, Timer>();
        }

        public void start_notifying(ITimerClient client_to_be_notified, TimeSpan span)
        {
            stop_notifying(client_to_be_notified);

            var timer = factory.create_for(span);
            timer.Elapsed += (sender, args) => client_to_be_notified.notify();
            timer.Start();
            timers[client_to_be_notified] = timer;
        }

        public void stop_notifying(ITimerClient client_to_stop_notifying)
        {
            if (!timers.ContainsKey(client_to_stop_notifying)) return;
            timers[client_to_stop_notifying].Stop();
            timers[client_to_stop_notifying].Dispose();
        }
    }
}