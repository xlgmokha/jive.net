using System;
using System.ComponentModel;

namespace gorilla.infrastructure.threading
{
    public interface IWorkerThread : IDisposable
    {
        event DoWorkEventHandler DoWork;
        event EventHandler Disposed;
        void begin();
    }
}