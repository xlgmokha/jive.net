using System.Collections.Generic;
using Castle.Core.Interceptor;

namespace gorilla.commons.infrastructure.thirdparty.Castle.DynamicProxy.Interceptors
{
    public interface MethodCallTracker<TypeToProxy> : IInterceptor
    {
        TypeToProxy target { get; }
        IEnumerable<string> methods_to_intercept();
    }
}