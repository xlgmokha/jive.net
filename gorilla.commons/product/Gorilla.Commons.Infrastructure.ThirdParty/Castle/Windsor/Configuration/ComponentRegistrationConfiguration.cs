using Castle.MicroKernel.Registration;
using Gorilla.Commons.Utility.Core;
using Gorilla.Commons.Utility.Extensions;

namespace Gorilla.Commons.Infrastructure.Castle.Windsor.Configuration
{
    public interface IRegistrationConfiguration : IConfiguration<ComponentRegistration>
    {
    }

    public class ComponentRegistrationConfiguration : IRegistrationConfiguration
    {
        public void configure(ComponentRegistration registration)
        {
            ConfigurationExtensions.then(new RegisterComponentContract()
                          .then(new ConfigureComponentLifestyle()), new ApplyLoggingInterceptor())
                //.then(new LogComponent())
                .configure(registration);
        }
    }
}