using System;

namespace Gorilla.Commons.Utility.Extensions
{
    public static class FuncExtensions
    {
        public static Func<T> memorize<T>(this Func<T> item) where T : class
        {
            T the_implementation = null;
            return () =>
                       {
                           if (null == the_implementation)
                           {
                               lock (typeof (FuncExtensions))
                               {
                                   if (null == the_implementation)
                                   {
                                       the_implementation = item();
                                   }
                               }
                           }
                           return the_implementation;
                       };
        }
    }
}