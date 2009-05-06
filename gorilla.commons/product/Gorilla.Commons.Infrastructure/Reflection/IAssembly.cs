using System;
using System.Collections.Generic;

namespace Gorilla.Commons.Infrastructure.Reflection
{
    public interface IAssembly
    {
        IEnumerable<Type> all_types();
    }
}