using System;
using System.Collections.Generic;

namespace Gorilla.Commons.Infrastructure.Reflection
{
    public interface Assembly
    {
        IEnumerable<Type> all_types();
    }
}