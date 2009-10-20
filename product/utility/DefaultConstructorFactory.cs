namespace gorilla.commons.utility
{
    public class DefaultConstructorFactory<T> : ComponentFactory<T> where T : new()
    {
        public T create()
        {
            return new T();
        }
    }
}