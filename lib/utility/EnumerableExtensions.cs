using System;
using System.Collections.Generic;
using System.Linq;

namespace jive.utility
{
  static public class EnumerableExtensions
  {
    static public IEnumerable<T> where<T>(this IEnumerable<T> items, Func<T, bool> condition_is_met)
    {
      return null == items ? Enumerable.Empty<T>() : items.Where(condition_is_met);
    }

    static public IList<T> databind<T>(this IEnumerable<T> items_to_bind_to)
    {
      return null == items_to_bind_to ? new List<T>() : items_to_bind_to.ToList();
    }

    static public IEnumerable<T> sorted_using<T>(this IEnumerable<T> items_to_sort, IComparer<T> sorting_algorithm)
    {
      var sorted_items = new List<T>(items_to_sort);
      sorted_items.Sort(sorting_algorithm);
      return sorted_items;
    }

    static public IEnumerable<T> all<T>(this IEnumerable<T> items)
    {
      foreach (var item in items ?? Enumerable.Empty<T>()) yield return item;
    }

    static public void each<T>(this IEnumerable<T> items, Action<T> action)
    {
      foreach (var item in items ?? Enumerable.Empty<T>()) action(item);
    }

    static public IEnumerable<T> join_with<T>(this IEnumerable<T> left, IEnumerable<T> right)
    {
      if (null == right) return left;

      var list = new List<T>();
      list.AddRange(left);
      list.AddRange(right);
      return list;
    }
  }
}
