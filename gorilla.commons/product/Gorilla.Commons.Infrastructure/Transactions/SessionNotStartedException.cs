using System;

namespace Gorilla.Commons.Infrastructure.Transactions
{
    public class SessionNotStartedException : Exception
    {
        public SessionNotStartedException() : base("A session could not be found. Did you forget to open a session?")
        {
        }
    }
}