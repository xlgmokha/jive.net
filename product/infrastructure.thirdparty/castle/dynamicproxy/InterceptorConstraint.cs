using System.Collections.Generic;

namespace gorilla.commons.infrastructure.thirdparty.Castle.DynamicProxy
{
    public interface InterceptorConstraint<TypeToPutConstraintOn> : ConstraintSelector<TypeToPutConstraintOn>
    {
        IEnumerable<string> methods_to_intercept();
    }
}