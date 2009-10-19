using System.Collections.Generic;

namespace gorilla.commons.utility
{
    public interface Registry<T> : IEnumerable<T>
    {
        IEnumerable<T> all();
    }
}