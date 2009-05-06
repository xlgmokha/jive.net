namespace Gorilla.Commons.Utility.Core
{
    public class ChainedConfiguration<T> : IConfiguration<T>
    {
        readonly IConfiguration<T> first;
        readonly IConfiguration<T> second;

        public ChainedConfiguration(IConfiguration<T> first, IConfiguration<T> second)
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