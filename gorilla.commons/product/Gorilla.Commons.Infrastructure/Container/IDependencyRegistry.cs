using System.Collections.Generic;

namespace Gorilla.Commons.Infrastructure.Container
{
    public interface IDependencyRegistry
    {
        Interface get_a<Interface>();
        IEnumerable<Interface> all_the<Interface>();
    }
}