namespace gorilla.commons.utility
{
    public interface Query<TOutput>
    {
        TOutput fetch();
    }

    public interface Query<TInput, TOutput>
    {
        TOutput fetch(TInput item);
    }
}