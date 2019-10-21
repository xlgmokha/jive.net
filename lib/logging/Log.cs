using System;
using jive.container;

namespace jive.logging
{
  static public class Log
  {
    static public Logger For<T>(T item_to_create_logger_for)
    {
      return For(typeof (T));
    }

    static public Logger For(Type type_to_create_a_logger_for)
    {
      try
      {
        return Resolve.the<LogFactory>().create_for(type_to_create_a_logger_for);
      }
      catch
      {
        return new TextLogger(Console.Out);
      }
    }
  }
}
