namespace gorilla.commons.infrastructure.thirdparty.Castle.DynamicProxy
{
    public interface IInterceptorConstraintFactory
    {
        InterceptorConstraint<Type> CreateFor<Type>();
    }

    public class InterceptorConstraintFactory : IInterceptorConstraintFactory
    {
        readonly MethodCallTrackerFactory factory;

        public InterceptorConstraintFactory() : this(new CastleDynamicMethodCallTrackerFactory())
        {
        }

        public InterceptorConstraintFactory(MethodCallTrackerFactory factory)
        {
            this.factory = factory;
        }

        public InterceptorConstraint<Type> CreateFor<Type>()
        {
            return new CastleDynamicInterceptorConstraint<Type>(factory.create_for<Type>());
        }
    }
}