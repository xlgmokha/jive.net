using System;
using gorilla.commons.utility;

namespace gorilla.commons.Utility
{
    public interface DisposableCommand : Command, IDisposable {}
}