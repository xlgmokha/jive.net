namespace Gorilla.Commons.Infrastructure.Proxies
{
    static public class ProxyFactory
    {
        static public T Create<T>(T target, params IInterceptor[] interceptors)
        {
            return new RemotingProxyFactory<T>(target, interceptors).CreateProxy();
        }
    }
}