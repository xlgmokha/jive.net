using System;
using Gorilla.Commons.Infrastructure.Logging;
using log4net;

namespace gorilla.commons.infrastructure.thirdparty.Log4Net
{
    public class Log4NetLogger : Logger
    {
        readonly ILog log;

        public Log4NetLogger(ILog log)
        {
            this.log = log;
        }

        public void informational(string formatted_string, params object[] arguments)
        {
            log.InfoFormat(formatted_string, arguments);
        }

        public void debug(string formatted_string, params object[] arguments)
        {
            log.DebugFormat(formatted_string, arguments);
        }

        public void error(Exception e)
        {
            log.Error(e.ToString());
        }
    }
}