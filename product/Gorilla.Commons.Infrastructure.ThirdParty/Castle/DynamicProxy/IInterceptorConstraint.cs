using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Gorilla.Commons.Infrastructure.Castle.DynamicProxy;
using gorilla.commons.infrastructure.thirdparty.Castle.DynamicProxy.Interceptors;

namespace gorilla.commons.infrastructure.thirdparty.Castle.DynamicProxy
{
    public interface IInterceptorConstraint<TypeToPutConstraintOn> : ConstraintSelector<TypeToPutConstraintOn>
    {
        IEnumerable<string> methods_to_intercept();
    }

    public class InterceptorConstraint<TypeToPutConstraintOn> : IInterceptorConstraint<TypeToPutConstraintOn>
    {
        readonly IMethodCallTracker<TypeToPutConstraintOn> call_tracker;
        bool intercept_all_calls;

        public InterceptorConstraint(IMethodCallTracker<TypeToPutConstraintOn> call_tracker)
        {
            this.call_tracker = call_tracker;
        }

        public TypeToPutConstraintOn intercept_on
        {
            get { return call_tracker.target; }
        }

        public void intercept_all()
        {
            intercept_all_calls = true;
        }

        public IEnumerable<string> methods_to_intercept()
        {
            return intercept_all_calls ? gell_all_methods() : call_tracker.methods_to_intercept();
        }

        IEnumerable<string> gell_all_methods()
        {
            return all_methods().Select(x => x.Name);
        }

        IEnumerable<MethodInfo> all_methods()
        {
            return typeof (TypeToPutConstraintOn).GetMethods(BindingFlags.Public | BindingFlags.Instance);
        }
    }
}