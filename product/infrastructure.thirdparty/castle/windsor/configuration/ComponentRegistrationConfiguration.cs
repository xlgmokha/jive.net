using Castle.MicroKernel.Registration;
using gorilla.commons.utility;

namespace gorilla.commons.infrastructure.thirdparty.Castle.Windsor.Configuration
{
    public class ComponentRegistrationConfiguration : RegistrationConfiguration
    {
        public void configure(ComponentRegistration registration)
        {
            new RegisterComponentContract()
                .then(new ConfigureComponentLifestyle()).then(new ApplyLoggingInterceptor())
                //.then(new LogComponent())
                .configure(registration);
        }
    }
}