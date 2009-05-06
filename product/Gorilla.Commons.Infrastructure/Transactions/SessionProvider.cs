namespace Gorilla.Commons.Infrastructure.Transactions
{
    public interface ISessionProvider
    {
        ISession get_the_current_session();
    }

    public class SessionProvider : ISessionProvider
    {
        readonly IContext context;
        readonly IKey<ISession> session_key;

        public SessionProvider(IContext context, IKey<ISession> session_key)
        {
            this.context = context;
            this.session_key = session_key;
        }

        public ISession get_the_current_session()
        {
            if (!context.contains(session_key)) throw new SessionNotStartedException();
            return context.value_for(session_key);
        }
    }
}