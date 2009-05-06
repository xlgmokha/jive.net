using System.Diagnostics;

namespace Gorilla.Commons.Infrastructure.Debugging
{
    static public class Launch
    {
        static public void the_debugger()
        {
#if DEBUG
            if (Debugger.IsAttached) Debugger.Break();
            else Debugger.Launch();
#endif
        }
    }
}