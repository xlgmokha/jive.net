using System;
using Castle.Core.Interceptor;

namespace gorilla.commons.infrastructure.thirdparty.Castle.DynamicProxy
{
    public interface ProxyBuilder<TypeToProxy>
    {
        ConstraintSelector<TypeToProxy> add_interceptor<Interceptor>(Interceptor interceptor)
            where Interceptor : IInterceptor;

        ConstraintSelector<TypeToProxy> add_interceptor<Interceptor>() where Interceptor : IInterceptor, new();
        TypeToProxy create_proxy_for(TypeToProxy target);
        TypeToProxy create_proxy_for(Func<TypeToProxy> target);
    }
}