using System;
using System.Collections.Generic;

namespace jive
{
  public interface Assembly
  {
    IEnumerable<Type> all_types();
  }
}
