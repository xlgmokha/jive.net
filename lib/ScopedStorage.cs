using System.Collections;

namespace jive
{
  public interface ScopedStorage
  {
    IDictionary provide_storage();
  }
}
