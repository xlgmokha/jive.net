using System;

namespace jive
{
  public class DependencyResolutionException<T> : Exception
  {
    public DependencyResolutionException(Exception inner_exception)
      : base("Could not resolve {0}".format(typeof (T).FullName), inner_exception)
    {
    }
  }
}
