using System;
using Castle.Core.Interceptor;

namespace Gorilla.Commons.Infrastructure.Castle.DynamicProxy
{
    public interface IProxyBuilder<TypeToProxy>
    {
        IConstraintSelector<TypeToProxy> add_interceptor<Interceptor>(Interceptor interceptor)
            where Interceptor : IInterceptor;

        IConstraintSelector<TypeToProxy> add_interceptor<Interceptor>() where Interceptor : IInterceptor, new();
        TypeToProxy create_proxy_for(TypeToProxy target);
        TypeToProxy create_proxy_for(Func<TypeToProxy> target);
    }
}