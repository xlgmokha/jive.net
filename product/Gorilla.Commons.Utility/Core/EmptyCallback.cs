namespace Gorilla.Commons.Utility.Core
{
    public class EmptyCallback<T> : ICallback<T>, ICallback
    {
        public void run(T item)
        {
        }

        public void run()
        {
        }
    }
}