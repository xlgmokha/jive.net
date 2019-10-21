using System;

namespace jive.utility
{
  public static class NumericConversions
  {
    public static int to_int<T>(this T item) where T : IConvertible
    {
      return Convert.ChangeType(item, typeof (int)).downcast_to<int>();
    }

    public static long to_long<T>(this T item) where T : IConvertible
    {
      return Convert.ChangeType(item, typeof (long)).downcast_to<long>();
    }

    public static double to_double<T>(this T item) where T : IConvertible
    {
      return Convert.ChangeType(item, typeof (double)).downcast_to<double>();
    }
  }
}
