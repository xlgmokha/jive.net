using System;
using System.Threading;

namespace Gorilla.Commons.Infrastructure.Threading
{
    [Serializable]
    internal class WorkItem : IAsyncResult
    {
        readonly object[] m_Args;
        readonly object m_AsyncState;
        bool m_Completed;
        readonly Delegate m_Method;
        readonly ManualResetEvent m_Event;
        object m_MethodReturnedValue;

        internal WorkItem(object async_state, Delegate method, object[] args)
        {
            m_AsyncState = async_state;
            m_Method = method;
            m_Args = args;
            m_Event = new ManualResetEvent(false);
            m_Completed = false;
        }

        //IAsyncResult properties 
        object IAsyncResult.AsyncState
        {
            get { return m_AsyncState; }
        }

        WaitHandle IAsyncResult.AsyncWaitHandle
        {
            get { return m_Event; }
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
                    return m_Completed;
                }
            }
            set
            {
                lock (this)
                {
                    m_Completed = value;
                }
            }
        }

        //This method is called on the worker thread to execute the method
        internal void CallBack()
        {
            MethodReturnedValue = m_Method.DynamicInvoke(m_Args);
            //Method is done. Signal the world
            m_Event.Set();
            Completed = true;
        }

        internal object MethodReturnedValue
        {
            get
            {
                object methodReturnedValue;
                lock (this)
                {
                    methodReturnedValue = m_MethodReturnedValue;
                }
                return methodReturnedValue;
            }
            set
            {
                lock (this)
                {
                    m_MethodReturnedValue = value;
                }
            }
        }
    }
}