using Castle.DynamicProxy;
using gorilla.commons.infrastructure.thirdparty.Castle.DynamicProxy.Interceptors;

namespace gorilla.commons.infrastructure.thirdparty.Castle.DynamicProxy
{
    public interface IMethodCallTrackerFactory
    {
        IMethodCallTracker<TypeToProxy> create_for<TypeToProxy>();
    }

    public class MethodCallTrackerFactory : IMethodCallTrackerFactory
    {
        private readonly ProxyGenerator generator;

        public MethodCallTrackerFactory() : this(new ProxyGenerator())
        {
        }

        public MethodCallTrackerFactory(ProxyGenerator generator)
        {
            this.generator = generator;
        }

        public IMethodCallTracker<TypeToProxy> create_for<TypeToProxy>()
        {
            var call_tracker_interceptor = new MethodCallTracker<TypeToProxy>();
            var target = generator.CreateInterfaceProxyWithoutTarget<TypeToProxy>(call_tracker_interceptor);
            call_tracker_interceptor.target = target;
            return call_tracker_interceptor;
        }
    }
}