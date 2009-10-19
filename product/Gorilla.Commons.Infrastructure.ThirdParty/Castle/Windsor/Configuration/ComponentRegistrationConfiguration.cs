using Castle.MicroKernel.Registration;
using gorilla.commons.utility;

namespace Gorilla.Commons.Infrastructure.Castle.Windsor.Configuration
{
    public interface IRegistrationConfiguration : Configuration<ComponentRegistration>
    {
    }

    public class ComponentRegistrationConfiguration : IRegistrationConfiguration
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