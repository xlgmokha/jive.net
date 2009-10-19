using Castle.Core;
using Castle.MicroKernel.Registration;
using Gorilla.Commons.Infrastructure.Logging;

namespace Gorilla.Commons.Infrastructure.Castle.Windsor.Configuration
{
    public class ApplyLoggingInterceptor : IRegistrationConfiguration
    {
        public void configure(ComponentRegistration registration)
        {
            var implementation = registration.Implementation;
            if (typeof (Loggable).IsAssignableFrom(implementation))
            {
                registration
                    .Interceptors(new InterceptorReference(typeof (ILoggingInterceptor)))
                    .First
                    .If((k, m) => true);
            }
        }
    }
}