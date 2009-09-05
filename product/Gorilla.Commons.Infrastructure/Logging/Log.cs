using System;
using Gorilla.Commons.Infrastructure.Container;
using Gorilla.Commons.Infrastructure.Logging.Console;

namespace Gorilla.Commons.Infrastructure.Logging
{
    static public class Log
    {
        static public ILogger For<T>(T item_to_create_logger_for)
        {
            return For(typeof (T));
        }

        static public ILogger For(Type type_to_create_a_logger_for)
        {
            try
            {
                return Resolve.the<ILogFactory>().create_for(type_to_create_a_logger_for);
            }
            catch
            {
                return new TextLogger(System.Console.Out);
            }
        }
    }
}