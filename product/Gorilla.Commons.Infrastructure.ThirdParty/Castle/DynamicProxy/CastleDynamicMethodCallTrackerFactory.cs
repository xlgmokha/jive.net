using Castle.DynamicProxy;
using gorilla.commons.infrastructure.thirdparty.Castle.DynamicProxy.Interceptors;

namespace gorilla.commons.infrastructure.thirdparty.Castle.DynamicProxy
{
    public class CastleDynamicMethodCallTrackerFactory : MethodCallTrackerFactory
    {
        private readonly ProxyGenerator generator;

        public CastleDynamicMethodCallTrackerFactory() : this(new ProxyGenerator())
        {
        }

        public CastleDynamicMethodCallTrackerFactory(ProxyGenerator generator)
        {
            this.generator = generator;
        }

        public MethodCallTracker<TypeToProxy> create_for<TypeToProxy>()
        {
            var call_tracker_interceptor = new CastleDynamicMethodCallTracker<TypeToProxy>();
            var target = generator.CreateInterfaceProxyWithoutTarget<TypeToProxy>(call_tracker_interceptor);
            call_tracker_interceptor.target = target;
            return call_tracker_interceptor;
        }
    }
}