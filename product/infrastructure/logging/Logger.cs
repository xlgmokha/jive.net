using System;

namespace Gorilla.Commons.Infrastructure.Logging
{
    public interface Logger
    {
        void informational(string formatted_string, params object[] arguments);
        void debug(string formatted_string, params object[] arguments);
        void error(Exception e);
    }
}