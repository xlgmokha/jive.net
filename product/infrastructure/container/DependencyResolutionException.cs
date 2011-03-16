using System;
using gorilla.utility;

namespace gorilla.infrastructure.container
{
    public class DependencyResolutionException<T> : Exception
    {
        public DependencyResolutionException(Exception inner_exception)
            : base("Could not resolve {0}".formatted_using(typeof (T).FullName), inner_exception)
        {
        }
    }
}