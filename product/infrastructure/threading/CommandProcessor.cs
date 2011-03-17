using System;
using gorilla.utility;

namespace gorilla.infrastructure.threading
{
    public interface CommandProcessor : Command
    {
        void add(Action command);
        void add(Command command_to_process);
        void stop();
    }
}