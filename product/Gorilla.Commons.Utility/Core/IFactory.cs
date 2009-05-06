namespace Gorilla.Commons.Utility.Core
{
    public interface IFactory<T>
    {
        T create();
    }
}