using System;
using Gorilla.Commons.Infrastructure.Logging;

namespace Gorilla.Commons.Infrastructure.Transactions
{
    public interface IUnitOfWork : IDisposable
    {
        void commit();
        bool is_dirty();
    }

    public class UnitOfWork : IUnitOfWork
    {
        readonly ISession session;
        readonly IContext context;
        readonly IKey<ISession> key;

        public UnitOfWork(ISession session, IContext context, IKey<ISession> key)
        {
            this.session = session;
            this.context = context;
            this.key = key;
        }

        public void commit()
        {
            if (is_dirty()) session.flush();
        }

        public bool is_dirty()
        {
            this.log().debug("is session dirty? {0}", session.is_dirty());
            return session.is_dirty();
        }

        public void Dispose()
        {
            context.remove(key);
            session.Dispose();
        }
    }
}