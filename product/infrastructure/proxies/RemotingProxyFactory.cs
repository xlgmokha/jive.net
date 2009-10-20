using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Remoting.Proxies;
using gorilla.commons.utility;

namespace Gorilla.Commons.Infrastructure.Proxies
{
    public class RemotingProxyFactory<T> : RealProxy
    {
        readonly T target;
        readonly IEnumerable<Interceptor> interceptors;

        public RemotingProxyFactory(T target, IEnumerable<Interceptor> interceptors) : base(typeof (T))
        {
            this.target = target;
            this.interceptors = interceptors;
        }

        public override IMessage Invoke(IMessage message)
        {
            if (message.is_an_implementation_of<IMethodCallMessage>())
            {
                var call = message.downcast_to<IMethodCallMessage>();
                var invocation = new MethodCallInvocation<T>(interceptors, call, target);
                invocation.proceed();
                return return_value(invocation.return_value, invocation.arguments, call);
            }
            return null;
        }

        IMessage return_value(object return_value, object[] out_parameters, IMethodCallMessage call)
        {
            return new ReturnMessage(return_value,
                                     out_parameters,
                                     out_parameters == null ? 0 : out_parameters.Length,
                                     call.LogicalCallContext, call);
        }

        public T create_proxy()
        {
            return GetTransparentProxy().downcast_to<T>();
        }
    }
}