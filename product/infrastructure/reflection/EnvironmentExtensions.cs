using System;

namespace Gorilla.Commons.Infrastructure.Reflection
{
    public static class EnvironmentExtensions
    {
        public static string startup_directory<T>(this T item)
        {
            return AppDomain.CurrentDomain.BaseDirectory;
        }
    }
}