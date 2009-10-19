using System.Collections.Generic;
using Castle.Core.Interceptor;
using gorilla.commons.utility;

namespace Gorilla.Commons.Infrastructure.Castle.DynamicProxy.Interceptors
{
    public class MethodCallTracker<TypeToProxy> : IMethodCallTracker<TypeToProxy>
    {
        readonly IList<string> the_name_of_each_method_to_intercept;

        public MethodCallTracker() : this(new List<string>())
        {
        }

        public MethodCallTracker(IList<string> the_name_of_each_method_to_intercept)
        {
            this.the_name_of_each_method_to_intercept = the_name_of_each_method_to_intercept;
        }

        public TypeToProxy target { get; set; }

        public void Intercept(IInvocation invocation)
        {
            set_return_value_for(invocation);
            if (the_name_of_each_method_to_intercept.Contains(invocation.Method.Name)) return;
            the_name_of_each_method_to_intercept.Add(invocation.Method.Name);
        }

        public IEnumerable<string> methods_to_intercept()
        {
            return the_name_of_each_method_to_intercept;
        }

        static void set_return_value_for(IInvocation invocation)
        {
            var return_type = invocation.Method.ReturnType;
            if (return_type == typeof (void)) return;
            invocation.ReturnValue = return_type.default_value();
        }
    }
}