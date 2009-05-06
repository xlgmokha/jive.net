using Castle.Core.Interceptor;
using Gorilla.Commons.Infrastructure.Threading;
using MoMoney.Utility.Core;

namespace Gorilla.Commons.Infrastructure.Castle.DynamicProxy.Interceptors
{
    public class RunOnBackgroundThreadInterceptor<CommandToExecute> : IInterceptor
        where CommandToExecute : IDisposableCommand
    {
        readonly IBackgroundThreadFactory thread_factory;

        public RunOnBackgroundThreadInterceptor(IBackgroundThreadFactory thread_factory)
        {
            this.thread_factory = thread_factory;
        }

        public virtual void Intercept(IInvocation invocation)
        {
            using (thread_factory.create_for<CommandToExecute>())
            {
                invocation.Proceed();
            }
        }
    }
}