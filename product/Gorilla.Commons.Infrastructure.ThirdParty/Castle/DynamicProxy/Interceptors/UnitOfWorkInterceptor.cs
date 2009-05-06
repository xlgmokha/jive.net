using Castle.Core.Interceptor;
using Gorilla.Commons.Infrastructure.Eventing;
using Gorilla.Commons.Infrastructure.Logging;
using Gorilla.Commons.Infrastructure.Transactions;
using Gorilla.Commons.Utility.Core;

namespace Gorilla.Commons.Infrastructure.Castle.DynamicProxy.Interceptors
{
    public interface IUnitOfWorkInterceptor : IInterceptor
    {
    }

    public class UnitOfWorkInterceptor : IUnitOfWorkInterceptor
    {
        readonly IEventAggregator broker;
        readonly IUnitOfWorkFactory factory;

        public UnitOfWorkInterceptor(IEventAggregator broker, IUnitOfWorkFactory factory)
        {
            this.broker = broker;
            this.factory = factory;
        }

        public void Intercept(IInvocation invocation)
        {
            using (var unit_of_work = factory.create())
            {
                this.log().debug("intercepting: {0}", invocation);
                invocation.Proceed();
                broker.publish<ICallback<IUnitOfWork>>(x => x.run(unit_of_work));
                this.log().debug("committing unit of work");
                unit_of_work.commit();
            }
        }
    }
}