namespace Gorilla.Commons.Infrastructure.Castle.DynamicProxy
{
    public interface IConstraintSelector<TypeToPutConstraintOn>
    {
        TypeToPutConstraintOn intercept_on { get; }
        void intercept_all();
    }
}