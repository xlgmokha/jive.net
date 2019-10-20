using gorilla.utility;

namespace gorilla.infrastructure.threading
{
    static public class ThreadingExtensions
    {
        static public BackgroundThread on_a_background_thread(this DisposableCommand command)
        {
            return new WorkderBackgroundThread(command);
        }
    }
}