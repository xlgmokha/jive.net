using System;
using System.Collections.Generic;
using System.Linq;
using Castle.Core.Interceptor;
using Gorilla.Commons.Infrastructure.Castle.DynamicProxy.Interceptors;

namespace gorilla.commons.infrastructure.thirdparty.Castle.DynamicProxy
{
    public class CastleDynamicProxyBuilder<TypeToProxy> : ProxyBuilder<TypeToProxy>
    {
        readonly IDictionary<IInterceptor, InterceptorConstraint<TypeToProxy>> constraints;
        readonly ProxyFactory proxy_factory;
        readonly InterceptorConstraintFactory constraint_factory;

        public CastleDynamicProxyBuilder() : this(new CastleDynamicProxyFactory(), new CastleDynamicInterceptorConstraintFactory())
        {
        }

        public CastleDynamicProxyBuilder(ProxyFactory proxy_factory, InterceptorConstraintFactory constraint_factory)
        {
            this.proxy_factory = proxy_factory;
            this.constraint_factory = constraint_factory;
            constraints = new Dictionary<IInterceptor, InterceptorConstraint<TypeToProxy>>();
        }

        public ConstraintSelector<TypeToProxy> add_interceptor<Interceptor>(Interceptor interceptor)
            where Interceptor : IInterceptor
        {
            var constraint = constraint_factory.CreateFor<TypeToProxy>();
            constraints.Add(interceptor, constraint);
            return constraint;
        }

        public ConstraintSelector<TypeToProxy> add_interceptor<Interceptor>() where Interceptor : IInterceptor, new()
        {
            return add_interceptor(new Interceptor());
        }

        public TypeToProxy create_proxy_for(TypeToProxy target)
        {
            return create_proxy_for(() => target);
        }

        public TypeToProxy create_proxy_for(Func<TypeToProxy> target)
        {
            return proxy_factory.create_proxy_for(target, all_interceptors_with_their_constraints().ToArray());
        }

        IEnumerable<IInterceptor> all_interceptors_with_their_constraints()
        {
            foreach (var pair in constraints)
            {
                var constraint = pair.Value;
                var interceptor = pair.Key;
                if (constraint.methods_to_intercept().Count() > 0)
                {
                    yield return new SelectiveInterceptor(constraint.methods_to_intercept(), interceptor);
                }
                else
                {
                    yield return interceptor;
                }
            }
        }
    }
}