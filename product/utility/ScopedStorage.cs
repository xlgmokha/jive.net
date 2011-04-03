using System.Collections;

namespace gorilla.utility
{
    public interface ScopedStorage
    {
        IDictionary provide_storage();
    }
}