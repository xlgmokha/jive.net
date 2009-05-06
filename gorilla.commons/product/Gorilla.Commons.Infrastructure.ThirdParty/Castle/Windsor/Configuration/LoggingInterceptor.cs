using System.Diagnostics;
using Castle.Core.Interceptor;
using Gorilla.Commons.Infrastructure.Logging;

namespace Gorilla.Commons.Infrastructure.Castle.Windsor.Configuration
{
    public interface ILoggingInterceptor : IInterceptor
    {
    }

    public class LoggingInterceptor : ILoggingInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            invocation.Proceed();
            stopwatch.Stop();
            this.log().debug("{0}.{1} took {2}", invocation.TargetType.Name, invocation.Method.Name, stopwatch.Elapsed);
        }
    }
}