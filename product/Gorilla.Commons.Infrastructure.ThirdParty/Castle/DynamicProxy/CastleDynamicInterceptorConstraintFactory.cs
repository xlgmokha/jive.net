namespace gorilla.commons.infrastructure.thirdparty.Castle.DynamicProxy
{
    public class CastleDynamicInterceptorConstraintFactory : InterceptorConstraintFactory
    {
        readonly MethodCallTrackerFactory factory;

        public CastleDynamicInterceptorConstraintFactory() : this(new CastleDynamicMethodCallTrackerFactory())
        {
        }

        public CastleDynamicInterceptorConstraintFactory(MethodCallTrackerFactory factory)
        {
            this.factory = factory;
        }

        public InterceptorConstraint<Type> CreateFor<Type>()
        {
            return new CastleDynamicInterceptorConstraint<Type>(factory.create_for<Type>());
        }
    }
}