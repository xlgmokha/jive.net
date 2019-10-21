using System;

namespace jive.infrastructure.threading
{
  public interface ITimerFactory
  {
    System.Timers.Timer create_for(TimeSpan span);
  }
}
