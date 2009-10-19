using System;
using System.IO;
using Gorilla.Commons.Infrastructure.Logging;
using Gorilla.Commons.Infrastructure.Reflection;
using log4net;
using log4net.Config;

namespace Gorilla.Commons.Infrastructure.Log4Net
{
    public class Log4NetLogFactory : LogFactory
    {
        public Log4NetLogFactory()
        {
            XmlConfigurator.Configure(PathToConfigFile());
        }

        public Logger create_for(Type type_to_create_logger_for)
        {
            return new Log4NetLogger(LogManager.GetLogger(type_to_create_logger_for));
        }

        private FileInfo PathToConfigFile()
        {
            return new FileInfo(Path.Combine(this.startup_directory(), "log4net.config.xml"));
        }
    }
}