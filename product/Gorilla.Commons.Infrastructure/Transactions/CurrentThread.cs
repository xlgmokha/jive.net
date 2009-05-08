using System.Threading;

namespace Gorilla.Commons.Infrastructure.Transactions
{
    public class CurrentThread : IThread
    {
        public T provide_slot_for<T>() where T : class, new()
        {
            var slot = Thread.GetNamedDataSlot(GetType().FullName + typeof (T).FullName);
            if (null == Thread.GetData(slot)) Thread.SetData(slot, new T());
            return (T) Thread.GetData(slot);
        }
    }
}