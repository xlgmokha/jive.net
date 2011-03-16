namespace gorilla.commons.utility
{
    public interface Mapper<in Input, out Output>
    {
        Output map_from(Input item);
    }
}