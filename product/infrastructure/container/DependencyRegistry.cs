using System.Collections.Generic;

namespace Gorilla.Commons.Infrastructure.Container
{
    public interface DependencyRegistry
    {
        Contract get_a<Contract>();
        IEnumerable<Contract> get_all<Contract>();
    }
}