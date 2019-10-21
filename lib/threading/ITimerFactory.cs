using System;

namespace jive.threading
{
  public interface ITimerFactory
  {
    System.Timers.Timer create_for(TimeSpan span);
  }
}
