using System;

namespace gorilla.utility
{
    public static class Clock
    {
        private static Func<DateTime> time_provider;

        static Clock()
        {
            reset();
        }

        public static Date today()
        {
            return time_provider();
        }

        public static DateTime now()
        {
            return time_provider();
        }

#if DEBUG
        public static void change_time_provider_to(Func<DateTime> new_time_provider)
        {
            if (new_time_provider != null) time_provider = new_time_provider;
        }
#endif

        public static void reset()
        {
            time_provider = () => DateTime.Now;
        }
    }
}