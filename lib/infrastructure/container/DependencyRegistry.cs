using System.Collections.Generic;

namespace jive.infrastructure.container
{
  public interface DependencyRegistry
  {
    Contract get_a<Contract>();
    IEnumerable<Contract> get_all<Contract>();
  }
}
