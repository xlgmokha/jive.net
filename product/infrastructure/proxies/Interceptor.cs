namespace Gorilla.Commons.Infrastructure.Proxies
{
    public interface Interceptor
    {
        void intercept(Invocation invocation);
    }
}