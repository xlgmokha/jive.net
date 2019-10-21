using System.Collections.Generic;

namespace jive.container
{
  public interface DependencyRegistry
  {
    Contract get_a<Contract>();
    IEnumerable<Contract> get_all<Contract>();
  }
}
