using System;
using System.Collections.Generic;
using System.Linq;
using Castle.Core.Interceptor;
using Castle.DynamicProxy;

namespace Gorilla.Commons.Infrastructure.Castle.DynamicProxy
{
    public class ProxyFactory : IProxyFactory
    {
        readonly ProxyGenerator generator;

        public ProxyFactory() : this(new ProxyGenerator())
        {
        }

        public ProxyFactory(ProxyGenerator generator)
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