using System;
using System.Collections.Generic;
using Autofac;
using Gorilla.Commons.Infrastructure.Container;

namespace Gorilla.Commons.Infrastructure.Autofac
{
    internal class AutofacDependencyRegistry : IDependencyRegistry
    {
        readonly Func<IContainer> container;

        public AutofacDependencyRegistry(Func<IContainer> container)
        {
            this.container = container;
        }

        public Interface get_a<Interface>()
        {
            return container().Resolve<Interface>();
        }

        public IEnumerable<Interface> all_the<Interface>()
        {
            return container().Resolve<IEnumerable<Interface>>();
        }
    }
}