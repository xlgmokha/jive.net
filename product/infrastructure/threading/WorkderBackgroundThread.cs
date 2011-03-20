using gorilla.utility;

namespace gorilla.infrastructure.threading
{
    public interface IBackgroundThread : DisposableCommand {}

    public class WorkderBackgroundThread : IBackgroundThread
    {
        readonly IWorkerThread worker_thread;

        public WorkderBackgroundThread(DisposableCommand command_to_execute) : this(command_to_execute, new WorkerThread()) {}

        public WorkderBackgroundThread(DisposableCommand command_to_execute, IWorkerThread worker_thread)
        {
            this.worker_thread = worker_thread;
            worker_thread.DoWork += (sender, e) => command_to_execute.run();
            worker_thread.Disposed += (sender, e) => command_to_execute.Dispose();
        }

        public void run()
        {
            worker_thread.begin();
        }

        public void Dispose()
        {
            worker_thread.Dispose();
        }
    }
}