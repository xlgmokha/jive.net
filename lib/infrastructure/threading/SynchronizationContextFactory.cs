using System.Threading;
using jive.infrastructure.container;
using jive.utility;

namespace jive.infrastructure.threading
{
  public interface ISynchronizationContextFactory : Factory<ISynchronizationContext> {}

  public class SynchronizationContextFactory : ISynchronizationContextFactory
  {
    readonly DependencyRegistry registry;

    public SynchronizationContextFactory(DependencyRegistry registry)
    {
      this.registry = registry;
    }

    public ISynchronizationContext create()
    {
      return new SynchronizedContext(registry.get_a<SynchronizationContext>());
    }
  }
}
