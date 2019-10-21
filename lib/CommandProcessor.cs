using System;

namespace jive
{
  public interface CommandProcessor : Command
  {
    void add(Action command);
    void add(Command command_to_process);
    void stop();
  }
}
