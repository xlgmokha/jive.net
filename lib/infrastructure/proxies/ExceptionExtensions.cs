using System;
using System.Reflection;

namespace jive.infrastructure.proxies
{
  static public class ExceptionExtensions
  {
    static readonly MethodInfo method =
      typeof (Exception).GetMethod("InternalPreserveStackTrace",
          BindingFlags.NonPublic | BindingFlags.Instance);

    static public Exception preserve_stack_trace(this Exception exception)
    {
      method.Invoke(exception, new object[0]);
      return exception;
    }
  }
}
