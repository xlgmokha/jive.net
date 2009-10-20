using System;
using Castle.Core.Interceptor;

namespace gorilla.commons.infrastructure.thirdparty.castle.dynamicproxy
{
    internal class LazyLoadedInterceptor<T> : IInterceptor
    {
        private readonly Func<T> get_the_implementation;

        public LazyLoadedInterceptor(Func<T> get_the_implementation)
        {
            this.get_the_implementation = get_the_implementation;
        }

        public void Intercept(IInvocation invocation)
        {
            var method = invocation.GetConcreteMethodInvocationTarget();
            invocation.ReturnValue = method.Invoke(get_the_implementation(), invocation.Arguments);
        }
    }
}