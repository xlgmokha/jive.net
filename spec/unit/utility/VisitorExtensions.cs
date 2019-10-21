using System.Collections.Generic;
using jive.utility;

namespace specs.unit.utility
{
  static public class VisitorExtensions
  {
    static public Result return_value_from_visiting_all_with<Result, T>(this IEnumerable<T> items, ValueReturningVisitor<Result, T> visitor)
    {
      visitor.reset();
      items.vist_all_with(visitor);
      return visitor.value;
    }

    static public void vist_all_with<T>(this IEnumerable<T> items, Visitor<T> visitor)
    {
      items.each(visitor.visit);
    }
  }
}
