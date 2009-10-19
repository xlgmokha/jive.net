using System.Collections;
using System.Collections.Generic;
using Gorilla.Commons.Infrastructure.Container;
using gorilla.commons.utility;

namespace Gorilla.Commons.Infrastructure.Registries
{
    public class DefaultRegistry<T> : Registry<T>
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

        public IEnumerator<T> GetEnumerator()
        {
            return all().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}