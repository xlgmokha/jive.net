namespace gorilla.commons.infrastructure.thirdparty.Castle.DynamicProxy
{
    public interface InterceptorConstraintFactory
    {
        InterceptorConstraint<Type> CreateFor<Type>();
    }
}