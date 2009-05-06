namespace Gorilla.Commons.Infrastructure.Proxies
{
    public interface IInterceptor
    {
        void Intercept(IInvocation invocation);
    }
}