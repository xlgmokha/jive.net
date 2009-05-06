using System.Collections.Generic;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using Gorilla.Commons.Utility.Extensions;

namespace Gorilla.Commons.Infrastructure.Proxies
{
    public class MethodCallInvocation<T> : IInvocation
    {
        readonly IMethodCallMessage call;
        readonly T target;
        readonly Stack<IInterceptor> interceptors;

        public MethodCallInvocation(IEnumerable<IInterceptor> interceptors, IMethodCallMessage call, T target)
        {
            this.call = call;
            this.target = target;
            this.interceptors = new Stack<IInterceptor>(interceptors);
            Arguments = call.Properties["__Args"].downcast_to<object[]>();
            Method = call.MethodBase.downcast_to<MethodInfo>();
        }

        public object[] Arguments { get; set; }

        public MethodInfo Method { get; set; }

        public object ReturnValue { get; set; }

        public void Proceed()
        {
            if (interceptors.Count > 0)
            {
                interceptors.Pop().Intercept(this);
                return;
            }

            try
            {
                ReturnValue = call.MethodBase.Invoke(target, Arguments);
            }
            catch (TargetInvocationException e)
            {
                throw e.InnerException.preserve_stack_trace();
            }
        }
    }
}