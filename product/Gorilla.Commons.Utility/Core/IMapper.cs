namespace Gorilla.Commons.Utility.Core
{
    public interface IMapper<Input, Output>
    {
        Output map_from(Input item);
    }
}