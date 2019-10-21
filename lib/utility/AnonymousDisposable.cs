using System;

namespace jive.utility
{
  public class AnonymousDisposable : IDisposable
  {
    readonly Action action;

    public AnonymousDisposable(Action action)
    {
      this.action = action;
    }

    public void Dispose()
    {
      action();
    }
  }
}
