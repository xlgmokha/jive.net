using Castle.MicroKernel.Registration;

namespace gorilla.commons.infrastructure.thirdparty.Castle.Windsor.Configuration
{
    public class LogComponent : RegistrationConfiguration
    {
        public void configure(ComponentRegistration registration)
        {
            var implementation = registration.Implementation;
        }
    }
}