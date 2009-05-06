using System;
using Castle.Core.Interceptor;

namespace Gorilla.Commons.Infrastructure.Castle.DynamicProxy
{
    public interface IProxyFactory
    {
        TypeToProxy create_proxy_for<TypeToProxy>(Func<TypeToProxy> implementation, params IInterceptor[] interceptors);
    }
}