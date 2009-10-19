using System;
using System.Collections.Generic;
using System.Linq;
using Castle.Core.Interceptor;
using Castle.DynamicProxy;
using Gorilla.Commons.Infrastructure.Castle.DynamicProxy;

namespace gorilla.commons.infrastructure.thirdparty.Castle.DynamicProxy
{
    public class CastleDynamicProxyFactory : ProxyFactory
    {
        readonly ProxyGenerator generator;

        public CastleDynamicProxyFactory() : this(new ProxyGenerator())
        {
        }

        public CastleDynamicProxyFactory(ProxyGenerator generator)
        {
            this.generator = generator;
        }

        public TypeToProxy create_proxy_for<TypeToProxy>(Func<TypeToProxy> implementation, params IInterceptor[] interceptors)
        {
            return create_proxy_for(lazy_load(implementation), interceptors);
        }

        T lazy_load<T>(Func<T> implementation)
        {
            if (typeof (T).IsInterface)
            {
                return generator.CreateInterfaceProxyWithoutTarget<T>(new LazyLoadedInterceptor<T>(implementation));
            }
            return generator.CreateClassProxy<T>(new LazyLoadedInterceptor<T>(implementation));
        }

        TypeToProxy create_proxy_for<TypeToProxy>(TypeToProxy implementation,
                                                  IEnumerable<IInterceptor> interceptors)
        {
            if (typeof (TypeToProxy).IsInterface)
            {
                return generator.CreateInterfaceProxyWithTarget<TypeToProxy>(implementation, interceptors.ToArray());
            }
            var list = interceptors.ToList();
            list.Add(new LazyLoadedInterceptor<TypeToProxy>(() => implementation));
            return generator.CreateClassProxy<TypeToProxy>(list.ToArray());
        }
    }
}