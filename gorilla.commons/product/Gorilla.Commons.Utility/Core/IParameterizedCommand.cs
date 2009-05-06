namespace Gorilla.Commons.Utility.Core
{
    public interface IParameterizedCommand<T>
    {
        void run(T item);
    }
}