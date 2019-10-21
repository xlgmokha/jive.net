using System;
using jive.utility;

namespace jive.threading
{
  public interface CommandProcessor : Command
  {
    void add(Action command);
    void add(Command command_to_process);
    void stop();
  }
}
