using System;
using Castle.Core.Interceptor;

namespace gorilla.commons.infrastructure.thirdparty.Castle.DynamicProxy
{
    public interface ProxyFactory
    {
        TypeToProxy create_proxy_for<TypeToProxy>(Func<TypeToProxy> implementation, params IInterceptor[] interceptors);
    }
}