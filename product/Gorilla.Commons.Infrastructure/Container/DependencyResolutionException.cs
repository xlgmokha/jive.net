using System;
using Gorilla.Commons.Utility.Extensions;

namespace Gorilla.Commons.Infrastructure.Container
{
    public class DependencyResolutionException<T> : Exception
    {
        public DependencyResolutionException(Exception inner_exception)
            : base("Could not resolve {0}".formatted_using(typeof (T).FullName), inner_exception)
        {
        }
    }
}