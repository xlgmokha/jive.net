using System;
using System.ComponentModel;
using Gorilla.Commons.Infrastructure.Logging;

namespace Gorilla.Commons.Infrastructure.Threading
{
    public class WorkerThread : Component, IWorkerThread
    {
        static readonly object do_work_key = new object();
        bool is_running;
        readonly Action background_thread;

        public WorkerThread()
        {
            background_thread = worker_thread_start;
        }

        public event DoWorkEventHandler DoWork
        {
            add { Events.AddHandler(do_work_key, value); }
            remove { Events.RemoveHandler(do_work_key, value); }
        }

        public void begin()
        {
            if (is_running)
            {
                throw new InvalidOperationException("Worker Thread Is Already Running");
            }
            is_running = true;
            background_thread.BeginInvoke(null, null);
        }

        void worker_thread_start()
        {
            try
            {
                var handler = (DoWorkEventHandler) Events[do_work_key];
                if (handler != null)
                {
                    handler(this, new DoWorkEventArgs(null));
                }
            }
            catch (Exception e)
            {
                this.log().error(e);
            }
        }
    }
}