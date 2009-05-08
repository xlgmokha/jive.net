using System.Collections;

namespace Gorilla.Commons.Infrastructure.Transactions
{
    public interface IScopedStorage
    {
        IDictionary provide_storage();
    }
}