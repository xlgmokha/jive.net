using Castle.Windsor;
using Gorilla.Commons.Utility.Core;

namespace Gorilla.Commons.Infrastructure.Castle.Windsor
{
    public interface IWindsorContainerFactory : IFactory<IWindsorContainer>
    {
    }

    public class WindsorContainerFactory : IWindsorContainerFactory
    {
        public IWindsorContainer create()
        {
            return new WindsorContainer();
        }
    }
}