using System;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Security.Permissions;
using System.Threading;

namespace Gorilla.Commons.Infrastructure.Threading
{
    [SecurityPermission(SecurityAction.Demand, ControlThread = true)]
    public class Synchronizer : ISynchronizeInvoke, IDisposable
    {
        readonly WorkerThread worker_thread;

        public Synchronizer()
        {
            worker_thread = new WorkerThread(this);
        }

        public bool InvokeRequired
        {
            get { return ReferenceEquals(Thread.CurrentThread, worker_thread); }
        }

        public IAsyncResult BeginInvoke(Delegate method, object[] args)
        {
            var result = new WorkItem(null, method, args);
            worker_thread.queue_work_item(result);
            return result;
        }

        public object EndInvoke(IAsyncResult result)
        {
            result.AsyncWaitHandle.WaitOne();
            return ((WorkItem) result).MethodReturnedValue;
        }

        public object Invoke(Delegate method, object[] args)
        {
            return EndInvoke(BeginInvoke(method, args));
        }

        ~Synchronizer()
        {
        }

        public void Dispose()
        {
            worker_thread.kill();
        }

        class WorkerThread
        {
            Thread thread;
            bool end_loop;
            readonly Mutex end_loop_mutex;
            readonly AutoResetEvent item_added;
            Synchronizer synchronizer;
            readonly Queue work_item_queue;

            internal WorkerThread(Synchronizer synchronizer)
            {
                this.synchronizer = synchronizer;
                end_loop = false;
                thread = null;
                end_loop_mutex = new Mutex();
                item_added = new AutoResetEvent(false);
                work_item_queue = new Queue();
                create_thread(true);
            }

            internal void queue_work_item(WorkItem work_item)
            {
                lock (work_item_queue.SyncRoot)
                {
                    work_item_queue.Enqueue(work_item);
                    item_added.Set();
                }
            }

            bool EndLoop
            {
                set
                {
                    end_loop_mutex.WaitOne();
                    end_loop = value;
                    end_loop_mutex.ReleaseMutex();
                }
                get
                {
                    var result = false;
                    end_loop_mutex.WaitOne();
                    result = end_loop;
                    end_loop_mutex.ReleaseMutex();
                    return result;
                }
            }

            Thread create_thread(bool auto_start)
            {
                if (thread != null)
                {
                    Debug.Assert(false);
                    return thread;
                }
                thread = new Thread(run) {Name = "Synchronizer Worker Thread"};
                if (auto_start)
                {
                    thread.Start();
                }
                return thread;
            }

            void start()
            {
                Debug.Assert(thread != null);
                Debug.Assert(thread.IsAlive == false);
                thread.Start();
            }

            bool queue_empty
            {
                get
                {
                    lock (work_item_queue.SyncRoot)
                    {
                        if (work_item_queue.Count > 0)
                        {
                            return false;
                        }
                        return true;
                    }
                }
            }

            WorkItem GetNext()
            {
                if (queue_empty)
                {
                    return null;
                }
                lock (work_item_queue.SyncRoot)
                {
                    return (WorkItem) work_item_queue.Dequeue();
                }
            }

            void run()
            {
                while (EndLoop == false)
                {
                    while (queue_empty == false)
                    {
                        if (EndLoop)
                        {
                            return;
                        }
                        var workItem = GetNext();
                        workItem.CallBack();
                    }
                    item_added.WaitOne();
                }
            }

            public void kill()
            {
                //Kill is called on client thread - must use cached thread object
                Debug.Assert(thread != null);
                if (thread.IsAlive == false)
                {
                    return;
                }
                EndLoop = true;
                item_added.Set();

                //Wait for thread to die
                thread.Join();
                if (end_loop_mutex != null)
                {
                    end_loop_mutex.Close();
                }
                if (item_added != null)
                {
                    item_added.Close();
                }
            }
        }
    }
}