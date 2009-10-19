using System;
using Castle.Core.Interceptor;
using Castle.DynamicProxy;
using Gorilla.Commons.Infrastructure.Castle.DynamicProxy;
using Gorilla.Commons.Infrastructure.Container;
using gorilla.commons.utility;

namespace Gorilla.Commons.Infrastructure
{
    public static class Lazy
    {
        public static T load<T>() where T : class
        {
            return create_proxy_for<T>(create_interceptor_for<T>());
        }

        static IInterceptor create_interceptor_for<T>() where T : class
        {
            Func<T> get_the_implementation = Resolve.the<T>;
            return new LazyLoadedInterceptor<T>(get_the_implementation.memorize());
        }

        static T create_proxy_for<T>(IInterceptor interceptor)
        {
            return new ProxyGenerator().CreateInterfaceProxyWithoutTarget<T>(interceptor);
        }
    }
}