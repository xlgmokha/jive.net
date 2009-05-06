using Castle.Core;
using Castle.MicroKernel.Registration;

namespace Gorilla.Commons.Infrastructure.Castle.Windsor.Configuration
{
    public class ConfigureComponentLifestyle : IRegistrationConfiguration
    {
        public void configure(ComponentRegistration registration)
        {
            var implementation = registration.Implementation;
            if (implementation.GetCustomAttributes(typeof (SingletonAttribute), false).Length > 0)
            {
                registration.LifeStyle.Is(LifestyleType.Singleton);
            }
            registration.LifeStyle.Is(LifestyleType.Transient);
        }
    }
}