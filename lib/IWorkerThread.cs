using System;
using System.ComponentModel;

namespace jive
{
  public interface IWorkerThread : IDisposable
  {
    event DoWorkEventHandler DoWork;
    event EventHandler Disposed;
    void begin();
  }
}
