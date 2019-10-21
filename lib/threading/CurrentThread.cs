using System.Threading;

namespace jive.threading
{
  public class CurrentThread : ApplicationThread
  {
    public T provide_slot_for<T>() where T : class, new()
    {
      var slot = Thread.GetNamedDataSlot(create_key_for<T>());
      if (null == Thread.GetData(slot)) Thread.SetData(slot, new T());
      return (T) Thread.GetData(slot);
    }

    string create_key_for<T>()
    {
      return Thread.CurrentThread.ManagedThreadId + GetType().FullName + typeof (T).FullName;
    }
  }
}
