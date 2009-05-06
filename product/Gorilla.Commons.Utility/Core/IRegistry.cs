using System.Collections.Generic;

namespace Gorilla.Commons.Utility.Core
{
    public interface IRegistry<T>
    {
        IEnumerable<T> all();
    }
}