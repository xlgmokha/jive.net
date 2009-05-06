using Castle.MicroKernel.Registration;

namespace Gorilla.Commons.Infrastructure.Castle.Windsor.Configuration
{
    public class LogComponent : IRegistrationConfiguration
    {
        public void configure(ComponentRegistration registration)
        {
            var implementation = registration.Implementation;
        }
    }
}