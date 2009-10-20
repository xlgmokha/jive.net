using System;
using System.Collections.Generic;
using Castle.Core;
using Castle.Windsor;
using Gorilla.Commons.Infrastructure.Container;
using gorilla.commons.infrastructure.thirdparty.Castle.DynamicProxy;
using gorilla.commons.utility;

namespace gorilla.commons.infrastructure.thirdparty.Castle.Windsor
{
    public class WindsorDependencyRegistry : DependencyRegistration, DependencyRegistry
    {
        readonly IWindsorContainer underlying_container;

        public WindsorDependencyRegistry(IWindsorContainer container)
        {
            underlying_container = container;
        }

        public Interface get_a<Interface>()
        {
            return underlying_container.Resolve<Interface>();
            //return underlying_container.Kernel.Resolve<Interface>();
        }

        public IEnumerable<Interface> get_all<Interface>()
        {
            return underlying_container.ResolveAll<Interface>();
        }

        public void singleton<Interface, Implementation>() where Implementation : Interface
        {
            var interface_type = typeof (Interface);
            var implementation_type = typeof (Implementation);
            underlying_container.AddComponent(create_a_key_using(interface_type, implementation_type), interface_type,
                                              implementation_type);
        }

        public void singleton<Contract>(Func<Contract> instance_of_the_contract)
        {
            underlying_container.Kernel.AddComponentInstance<Contract>(instance_of_the_contract());
        }

        public void transient<Interface, Implementation>() where Implementation : Interface
        {
            transient(typeof (Interface), typeof (Implementation));
        }

        public void transient(Type contract, Type implementation)
        {
            underlying_container.AddComponentLifeStyle(
                create_a_key_using(contract, implementation),
                contract, implementation, LifestyleType.Transient);
        }

        string create_a_key_using(Type interface_type, Type implementation_type)
        {
            return "{0}-{1}".formatted_using(interface_type.FullName, implementation_type.FullName);
        }

        public void proxy<T>(Configuration<ProxyBuilder<T>> configuration, Func<T> target)
        {
            var builder = new CastleDynamicProxyBuilder<T>();
            configuration.configure(builder);
            singleton(() => builder.create_proxy_for(target));
        }

        public void proxy<T, Configuration>(Func<T> target)
            where Configuration : Configuration<ProxyBuilder<T>>, new()
        {
            proxy(new Configuration(), target);
        }

        public DependencyRegistry build()
        {
            return this;
        }
    }
}