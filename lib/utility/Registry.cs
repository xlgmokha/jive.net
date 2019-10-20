using System.Collections.Generic;

namespace gorilla.utility
{
    public interface Registry<out T> : IEnumerable<T>
    {
        IEnumerable<T> all();
    }
}