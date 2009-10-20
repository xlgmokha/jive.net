using System.Collections;
using System.Collections.Generic;
using Gorilla.Commons.Infrastructure.Container;
using gorilla.commons.utility;

namespace Gorilla.Commons.Infrastructure.Registries
{
    public class DefaultRegistry<T> : Registry<T>
    {
        readonly DependencyRegistry registry;

        public DefaultRegistry(DependencyRegistry registry)
        {
            this.registry = registry;
        }

        public IEnumerable<T> all()
        {
            return registry.get_all<T>();
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