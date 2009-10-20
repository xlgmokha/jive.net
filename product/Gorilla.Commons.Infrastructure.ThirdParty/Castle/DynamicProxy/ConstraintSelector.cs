namespace gorilla.commons.infrastructure.thirdparty.Castle.DynamicProxy
{
    public interface ConstraintSelector<TypeToPutConstraintOn>
    {
        TypeToPutConstraintOn intercept_on { get; }
        void intercept_all();
    }
}