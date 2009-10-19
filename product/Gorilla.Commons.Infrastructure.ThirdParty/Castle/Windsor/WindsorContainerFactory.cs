using Castle.Windsor;
using gorilla.commons.utility;

namespace Gorilla.Commons.Infrastructure.Castle.Windsor
{
    public interface IWindsorContainerFactory : Factory<IWindsorContainer>
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