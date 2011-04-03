using System;

namespace gorilla.infrastructure.threading
{
    public interface Timer
    {
        void start_notifying(TimerClient client_to_be_notified, TimeSpan span);
        void stop_notifying(TimerClient client_to_stop_notifying);
    }
}