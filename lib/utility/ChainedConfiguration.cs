namespace gorilla.utility
{
    public class ChainedConfiguration<T> : Configuration<T>
    {
        readonly Configuration<T> first;
        readonly Configuration<T> second;

        public ChainedConfiguration(Configuration<T> first, Configuration<T> second)
        {
            this.first = first;
            this.second = second;
        }

        public void configure(T item)
        {
            first.configure(item);
            second.configure(item);
        }
    }
}