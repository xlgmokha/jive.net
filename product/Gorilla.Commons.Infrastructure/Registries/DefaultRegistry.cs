using System.Collections.Generic;
using Gorilla.Commons.Infrastructure.Container;
using Gorilla.Commons.Utility.Core;

namespace Gorilla.Commons.Infrastructure.Registries
{
    public class DefaultRegistry<T> : IRegistry<T>
    {
        readonly IDependencyRegistry registry;

        public DefaultRegistry(IDependencyRegistry registry)
        {
            this.registry = registry;
        }

        public IEnumerable<T> all()
        {
            return registry.all_the<T>();
        }
    }
}