using Castle.MicroKernel.Registration;

namespace Gorilla.Commons.Infrastructure.Castle.Windsor.Configuration
{
    public class RegisterComponentContract : IRegistrationConfiguration
    {
        public void configure(ComponentRegistration registration)
        {
            var implementation = registration.Implementation;
            if (implementation.GetInterfaces().Length == 0)
            {
                registration.For(implementation);
            }
        }
    }
}