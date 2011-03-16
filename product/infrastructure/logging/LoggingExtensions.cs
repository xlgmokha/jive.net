using System;

namespace gorilla.infrastructure.logging
{
    public static class LoggingExtensions
    {
        public static Logger log<T>(this T item_to_log)
        {
            return Log.For(item_to_log);
        }

        public static void add_to_log(this Exception error_to_log)
        {
            Log.For(error_to_log).error(error_to_log);
        }
    }
}