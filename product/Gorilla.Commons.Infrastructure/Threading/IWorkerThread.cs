using System;
using System.ComponentModel;

namespace Gorilla.Commons.Infrastructure.Threading
{
    public interface IWorkerThread : IDisposable
    {
        event DoWorkEventHandler DoWork;
        event EventHandler Disposed;
        void begin();
    }
}