using System.Collections;
using System.Collections.Generic;
using jive.container;
using jive.utility;

namespace jive
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
