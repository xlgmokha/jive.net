using System.Collections;

namespace Gorilla.Commons.Infrastructure.Transactions
{
    public class SingletonScopedStorage : IScopedStorage
    {
        static public readonly IDictionary storage = new Hashtable();

        public IDictionary provide_storage()
        {
            return storage;
        }
    }
}