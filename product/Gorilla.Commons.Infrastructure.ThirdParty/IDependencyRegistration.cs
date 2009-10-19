using System;
using Gorilla.Commons.Infrastructure.Castle.DynamicProxy;
using Gorilla.Commons.Infrastructure.Container;
using gorilla.commons.utility;

namespace Gorilla.Commons.Infrastructure
{
    public interface IDependencyRegistration : Builder<DependencyRegistry>
    {
        void singleton<Contract, Implementation>() where Implementation : Contract;
        void singleton<Contract>(Func<Contract> instance_of_the_contract);
        void transient<Contract, Implementation>() where Implementation : Contract;
        void transient(Type contract, Type implementation);
        void proxy<T>(Configuration<ProxyBuilder<T>> configuration, Func<T> target);
        void proxy<T, Configuration>(Func<T> target) where Configuration : Configuration<ProxyBuilder<T>>, new();
    }
}