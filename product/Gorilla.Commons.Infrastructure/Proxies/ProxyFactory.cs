namespace Gorilla.Commons.Infrastructure.Proxies
{
    static public class ProxyFactory
    {
        static public T create<T>(T target, params IInterceptor[] interceptors)
        {
            return new RemotingProxyFactory<T>(target, interceptors).create_proxy();
        }
    }
}