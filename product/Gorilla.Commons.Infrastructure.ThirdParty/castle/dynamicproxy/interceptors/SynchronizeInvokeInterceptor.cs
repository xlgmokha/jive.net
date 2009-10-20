using System;
using System.ComponentModel;
using Castle.Core.Interceptor;
using gorilla.commons.utility;

namespace gorilla.commons.infrastructure.thirdparty.castle.dynamicproxy.interceptors
{
    public interface SynchronizedInterceptor : IInterceptor
    {
    }

    public class SynchronizeInvokeInterceptor<T> : SynchronizedInterceptor where T : ISynchronizeInvoke
    {
        public void Intercept(IInvocation invocation)
        {
            var target = invocation.InvocationTarget.downcast_to<T>();
            target.BeginInvoke(do_it(invocation.Proceed), new object[] {});
        }

        Delegate do_it(Action action)
        {
            return action;
        }
    }
}