namespace Gorilla.Commons.Utility.Core
{
    public interface IQuery<TOutput>
    {
        TOutput fetch();
    }

    public interface IQuery<TInput, TOutput>
    {
        TOutput fetch(TInput item);
    }
}