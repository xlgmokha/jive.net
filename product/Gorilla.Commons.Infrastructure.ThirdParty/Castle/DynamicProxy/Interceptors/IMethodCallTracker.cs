using System.Collections.Generic;
using Castle.Core.Interceptor;

namespace Gorilla.Commons.Infrastructure.Castle.DynamicProxy.Interceptors
{
    public interface IMethodCallTracker<TypeToProxy> : IInterceptor
    {
        TypeToProxy target { get; }
        IEnumerable<string> methods_to_intercept();
    }
}