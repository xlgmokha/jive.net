using gorilla.commons.infrastructure.thirdparty.Castle.DynamicProxy.Interceptors;

namespace gorilla.commons.infrastructure.thirdparty.Castle.DynamicProxy
{
    public interface MethodCallTrackerFactory
    {
        MethodCallTracker<TypeToProxy> create_for<TypeToProxy>();
    }
}