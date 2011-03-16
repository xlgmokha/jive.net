using System.Collections.Generic;

namespace gorilla.infrastructure.container
{
    public interface DependencyRegistry
    {
        Contract get_a<Contract>();
        IEnumerable<Contract> get_all<Contract>();
    }
}