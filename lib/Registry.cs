using System.Collections.Generic;

namespace jive
{
  public interface Registry<out T> : IEnumerable<T>
  {
    IEnumerable<T> all();
  }
}
