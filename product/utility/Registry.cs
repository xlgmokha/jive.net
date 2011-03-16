using System.Collections.Generic;

namespace gorilla.commons.utility
{
    public interface Registry<out T> : IEnumerable<T>
    {
        IEnumerable<T> all();
    }
}