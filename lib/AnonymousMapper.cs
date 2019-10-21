using System;

namespace jive
{
  public class AnonymousMapper<Input, Output> : Mapper<Input, Output>
  {
    readonly Converter<Input, Output> converter;

    public AnonymousMapper(Converter<Input, Output> converter)
    {
      this.converter = converter;
    }

    public Output map_from(Input item)
    {
      return converter(item);
    }
  }
}
