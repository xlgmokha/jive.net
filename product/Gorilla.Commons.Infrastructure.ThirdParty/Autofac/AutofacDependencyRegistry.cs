using System;
using System.Collections.Generic;
using Autofac;
using Gorilla.Commons.Infrastructure.Container;

namespace Gorilla.Commons.Infrastructure.Autofac
{
    internal class AutofacDependencyRegistry : DependencyRegistry
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

        public IEnumerable<Interface> get_all<Interface>()
        {
            return container().Resolve<IEnumerable<Interface>>();
        }
    }
}