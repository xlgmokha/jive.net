using Castle.Core;
using Castle.MicroKernel.Registration;
using Gorilla.Commons.Infrastructure.Logging;

namespace gorilla.commons.infrastructure.thirdparty.Castle.Windsor.Configuration
{
    public class ApplyLoggingInterceptor : RegistrationConfiguration
    {
        public void configure(ComponentRegistration registration)
        {
            var implementation = registration.Implementation;
            if (typeof (Loggable).IsAssignableFrom(implementation))
            {
                registration
                    .Interceptors(new InterceptorReference(typeof (LoggingInterceptor)))
                    .First
                    .If((k, m) => true);
            }
        }
    }
}