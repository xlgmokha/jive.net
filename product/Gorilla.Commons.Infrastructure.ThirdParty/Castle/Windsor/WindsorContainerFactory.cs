using Castle.Windsor;
using gorilla.commons.utility;

namespace gorilla.commons.infrastructure.thirdparty.Castle.Windsor
{
    public class WindsorContainerFactory : Factory<IWindsorContainer>
    {
        public IWindsorContainer create()
        {
            return new WindsorContainer();
        }
    }
}