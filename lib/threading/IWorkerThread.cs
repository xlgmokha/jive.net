using System;
using System.ComponentModel;

namespace jive.threading
{
  public interface IWorkerThread : IDisposable
  {
    event DoWorkEventHandler DoWork;
    event EventHandler Disposed;
    void begin();
  }
}
