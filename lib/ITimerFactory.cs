using System;

namespace jive
{
  public interface ITimerFactory
  {
    System.Timers.Timer create_for(TimeSpan span);
  }
}
