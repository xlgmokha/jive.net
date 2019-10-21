using System.Collections.Generic;

namespace jive.utility
{
  public interface Registry<out T> : IEnumerable<T>
  {
    IEnumerable<T> all();
  }
}
