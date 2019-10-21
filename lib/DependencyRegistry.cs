using System.Collections.Generic;

namespace jive
{
  public interface DependencyRegistry
  {
    Contract get_a<Contract>();
    IEnumerable<Contract> get_all<Contract>();
  }
}
