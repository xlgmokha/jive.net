namespace gorilla.utility
{
    public class EmptyCallback<T> : Callback<T>, Callback
    {
        public void run(T item) {}

        public void run() {}
    }
}