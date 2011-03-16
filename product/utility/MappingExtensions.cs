using System;
using System.Collections.Generic;
using System.Linq;

namespace gorilla.utility
{
    public static class MappingExtensions
    {
        public static Output map_using<Input, Output>(this Input item, Converter<Input, Output> conversion)
        {
            return conversion(item);
        }

        public static Output map_using<Input, Output>(this Input item, Mapper<Input, Output> mapper)
        {
            return map_using(item, x => mapper.map_from(x));
        }

        public static IEnumerable<Output> map_all_using<Input, Output>(this IEnumerable<Input> items,
                                                                       Converter<Input, Output> mapper)
        {
            return null == items ? new List<Output>() : items.Select(x => mapper(x));
        }

        public static IEnumerable<Output> map_all_using<Input, Output>(this IEnumerable<Input> items,
                                                                       Mapper<Input, Output> mapper)
        {
            return map_all_using(items, x => mapper.map_from(x));
        }

        public static Mapper<Left, Right> then<Left, Middle, Right>(this Mapper<Left, Middle> left,
                                                                    Mapper<Middle, Right> right)
        {
            return new ChainedMapper<Left, Middle, Right>(left, right);
        }
    }
}