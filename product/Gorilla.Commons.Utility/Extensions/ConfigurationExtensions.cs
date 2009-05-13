using Gorilla.Commons.Utility.Core;

namespace Gorilla.Commons.Utility.Extensions
{
    static public class ConfigurationExtensions
    {
        static public IConfiguration<T> then<T>(this IConfiguration<T> first, IConfiguration<T> second)
        {
            return new ChainedConfiguration<T>(first, second);
        }

        static public T and_configure_with<T>(this T item, IConfiguration<T> configuration)
        {
            configuration.configure(item);
            return item;
        }
    }
}