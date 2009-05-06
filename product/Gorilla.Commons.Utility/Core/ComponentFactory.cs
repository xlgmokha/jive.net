namespace Gorilla.Commons.Utility.Core
{
    public interface IComponentFactory<T> : IFactory<T> where T : new()
    {
    }

    public class ComponentFactory<T> : IComponentFactory<T> where T : new()
    {
        public T create()
        {
            return new T();
        }
    }
}