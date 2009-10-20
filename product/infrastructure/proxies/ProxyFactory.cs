namespace Gorilla.Commons.Infrastructure.Proxies
{
    static public class ProxyFactory
    {
        static public T create<T>(T target, params Interceptor[] interceptors)
        {
            return new RemotingProxyFactory<T>(target, interceptors).create_proxy();
        }
    }
}