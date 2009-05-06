using Gorilla.Commons.Utility.Core;

namespace Gorilla.Commons.Utility.Extensions
{
    public static class ConfigurationExtensions
    {
        public static IConfiguration<T> then<T>(this IConfiguration<T> first, IConfiguration<T> second)
        {
            return new ChainedConfiguration<T>(first, second);
        }
    }
}