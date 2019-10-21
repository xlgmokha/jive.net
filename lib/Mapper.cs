namespace jive
{
  public interface Mapper<in Input, out Output>
  {
    Output map_from(Input item);
  }

  public interface Mapper
  {
    Output map_from<Input, Output>(Input item);
  }
}
