using System;
using System.Collections.Generic;

namespace gorilla.infrastructure.reflection
{
    public interface Assembly
    {
        IEnumerable<Type> all_types();
    }
}