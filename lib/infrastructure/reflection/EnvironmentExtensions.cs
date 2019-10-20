using System;

namespace gorilla.infrastructure.reflection
{
    public static class EnvironmentExtensions
    {
        public static string startup_directory<T>(this T item)
        {
            return AppDomain.CurrentDomain.BaseDirectory;
        }
    }
}