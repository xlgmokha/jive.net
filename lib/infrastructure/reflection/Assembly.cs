using System;
using System.Collections.Generic;

namespace jive.infrastructure.reflection
{
  public interface Assembly
  {
    IEnumerable<Type> all_types();
  }
}
