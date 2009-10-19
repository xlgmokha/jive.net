using System.Collections.Generic;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using gorilla.commons.utility;

namespace Gorilla.Commons.Infrastructure.Proxies
{
    public class MethodCallInvocation<T> : Invocation
    {
        readonly IMethodCallMessage call;
        readonly T target;
        readonly Stack<Interceptor> interceptors;

        public MethodCallInvocation(IEnumerable<Interceptor> interceptors, IMethodCallMessage call, T target)
        {
            this.call = call;
            this.target = target;
            this.interceptors = new Stack<Interceptor>(interceptors);
            arguments = call.Properties["__Args"].downcast_to<object[]>();
            method = call.MethodBase.downcast_to<MethodInfo>();
        }

        public object[] arguments { get; set; }

        public MethodInfo method { get; set; }

        public object return_value { get; set; }

        public void proceed()
        {
            if (interceptors.Count > 0)
            {
                interceptors.Pop().intercept(this);
                return;
            }

            try
            {
                return_value = call.MethodBase.Invoke(target, arguments);
            }
            catch (TargetInvocationException e)
            {
                throw e.InnerException.preserve_stack_trace();
            }
        }
    }
}