using System;

namespace jive
{
  static public class CommandExtensions
  {
    static public jive.Command then<Command>(this jive.Command left) where Command : jive.Command, new()
    {
      return then(left, new Command());
    }

    static public Command then(this Command left, Command right)
    {
      return new ChainedCommand(left, right);
    }

    static public Command then(this Command left, Action right)
    {
      return new ChainedCommand(left, new AnonymousCommand(right));
    }
  }
}
