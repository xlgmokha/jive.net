using System.Collections;

namespace Gorilla.Commons.Infrastructure.Transactions
{
    public class SingletonScopedStorage : IScopedStorage
    {
        static readonly IDictionary storage = new Hashtable();

        public IDictionary provide_storage()
        {
            return storage;
        }
    }
}