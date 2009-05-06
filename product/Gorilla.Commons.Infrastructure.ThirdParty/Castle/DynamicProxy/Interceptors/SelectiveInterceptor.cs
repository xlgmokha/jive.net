using System.Collections.Generic;
using Castle.Core.Interceptor;

namespace Gorilla.Commons.Infrastructure.Castle.DynamicProxy.Interceptors
{
    public class SelectiveInterceptor : IInterceptor
    {
        private readonly IList<string> methods_to_intercept;
        private readonly IInterceptor underlying_interceptor;

        public SelectiveInterceptor(IEnumerable<string> methods_to_intercept, IInterceptor underlying_interceptor)
        {
            this.methods_to_intercept = new List<string>(methods_to_intercept);
            this.underlying_interceptor = underlying_interceptor;
        }

        public void Intercept(IInvocation invocation)
        {
            if (methods_to_intercept.Contains(invocation.Method.Name))
            {
                underlying_interceptor.Intercept(invocation);
                return;
            }
            invocation.Proceed();
        }
    }
}