using System;
using jive.utility;

namespace jive.infrastructure.container
{
  public class DependencyResolutionException<T> : Exception
  {
    public DependencyResolutionException(Exception inner_exception)
      : base("Could not resolve {0}".format(typeof (T).FullName), inner_exception)
    {
    }
  }
}
