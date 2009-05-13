namespace Gorilla.Commons.Infrastructure.Proxies
{
    public interface IInterceptor
    {
        void intercept(IInvocation invocation);
    }
}