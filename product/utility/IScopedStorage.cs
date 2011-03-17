using System.Collections;

namespace gorilla.utility
{
    public interface IScopedStorage
    {
        IDictionary provide_storage();
    }
}