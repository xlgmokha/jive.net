namespace gorilla.commons.utility
{
    public interface Mapper<Input, Output>
    {
        Output map_from(Input item);
    }
}