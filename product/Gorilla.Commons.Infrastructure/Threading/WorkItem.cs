using System;
using System.Threading;

namespace Gorilla.Commons.Infrastructure.Threading
{
    [Serializable]
    internal class WorkItem : IAsyncResult
    {
        readonly object[] args;
        readonly object async_state;
        bool completed;
        readonly Delegate method;
        readonly ManualResetEvent reset_event;
        object returned_value;

        internal WorkItem(object async_state, Delegate method, object[] args)
        {
            this.async_state = async_state;
            this.method = method;
            this.args = args;
            reset_event = new ManualResetEvent(false);
            completed = false;
        }

        //IAsyncResult properties 
        object IAsyncResult.AsyncState
        {
            get { return async_state; }
        }

        WaitHandle IAsyncResult.AsyncWaitHandle
        {
            get { return reset_event; }
        }

        bool IAsyncResult.CompletedSynchronously
        {
            get { return false; }
        }

        bool IAsyncResult.IsCompleted
        {
            get { return Completed; }
        }

        bool Completed
        {
            get
            {
                lock (this)
                {
                    return completed;
                }
            }
            set
            {
                lock (this)
                {
                    completed = value;
                }
            }
        }

        //This method is called on the worker thread to execute the method
        internal void CallBack()
        {
            MethodReturnedValue = method.DynamicInvoke(args);
            //Method is done. Signal the world
            reset_event.Set();
            Completed = true;
        }

        internal object MethodReturnedValue
        {
            get
            {
                object method_returned_value;
                lock (this)
                {
                    method_returned_value = returned_value;
                }
                return method_returned_value;
            }
            set
            {
                lock (this)
                {
                    returned_value = value;
                }
            }
        }
    }
}