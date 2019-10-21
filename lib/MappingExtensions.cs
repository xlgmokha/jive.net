using System;
using System.Collections.Generic;
using System.Linq;

namespace jive
{
  static public class MappingExtensions
  {
    static public Output map_using<Input, Output>(this Input item, Converter<Input, Output> conversion)
    {
      return conversion(item);
    }

    static public Output map_using<Input, Output>(this Input item, Mapper<Input, Output> mapper)
    {
      return map_using(item, x => mapper.map_from(x));
    }

    static public Output map_using<Input, Output>(this Input item, Mapper mapper)
    {
      return map_using(item, x => mapper.map_from<Input, Output>(x));
    }

    static public IEnumerable<Output> map_all_using<Input, Output>(this IEnumerable<Input> items,
        Converter<Input, Output> mapper)
    {
      return null == items ? Enumerable.Empty<Output>() : items.Select(x => mapper(x));
    }

    static public IEnumerable<Output> map_all_using<Input, Output>(this IEnumerable<Input> items,
        Mapper<Input, Output> mapper)
    {
      return map_all_using(items, x => mapper.map_from(x));
    }

    static public IEnumerable<Output> map_all_using<Input, Output>(this IEnumerable<Input> items,
        Mapper mapper)
    {
      return map_all_using(items, x => mapper.map_from<Input, Output>(x));
    }

    static public Mapper<Left, Right> then<Left, Middle, Right>(this Mapper<Left, Middle> left,
        Mapper<Middle, Right> right)
    {
      return new ChainedMapper<Left, Middle, Right>(left, right);
    }
  }
}
