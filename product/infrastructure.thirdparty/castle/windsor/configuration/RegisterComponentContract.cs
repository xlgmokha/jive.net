using Castle.MicroKernel.Registration;

namespace gorilla.commons.infrastructure.thirdparty.Castle.Windsor.Configuration
{
    public class RegisterComponentContract : RegistrationConfiguration
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