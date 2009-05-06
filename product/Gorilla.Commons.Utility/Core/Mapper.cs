using System;

namespace Gorilla.Commons.Utility.Core
{
    public class Mapper<Input, Output> : IMapper<Input, Output>
    {
        private readonly Converter<Input, Output> converter;

        public Mapper(Converter<Input, Output> converter)
        {
            this.converter = converter;
        }

        public Output map_from(Input item)
        {
            return converter(item);
        }
    }
}