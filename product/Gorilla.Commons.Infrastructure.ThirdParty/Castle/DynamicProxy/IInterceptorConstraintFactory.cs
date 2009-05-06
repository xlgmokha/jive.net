namespace Gorilla.Commons.Infrastructure.Castle.DynamicProxy
{
    public interface IInterceptorConstraintFactory
    {
        IInterceptorConstraint<Type> CreateFor<Type>();
    }

    public class InterceptorConstraintFactory : IInterceptorConstraintFactory
    {
        readonly IMethodCallTrackerFactory factory;

        public InterceptorConstraintFactory() : this(new MethodCallTrackerFactory())
        {
        }

        public InterceptorConstraintFactory(IMethodCallTrackerFactory factory)
        {
            this.factory = factory;
        }

        public IInterceptorConstraint<Type> CreateFor<Type>()
        {
            return new InterceptorConstraint<Type>(factory.create_for<Type>());
        }
    }
}