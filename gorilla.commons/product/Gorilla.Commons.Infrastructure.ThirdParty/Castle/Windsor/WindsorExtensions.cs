using System;
using Castle.MicroKernel.Registration;

namespace Gorilla.Commons.Infrastructure.Castle.Windsor
{
    public static class WindsorExtensions
    {
        public static BasedOnDescriptor LastInterface(this ServiceDescriptor descriptor)
        {
            return descriptor.Select((type, base_type) =>
                                         {
                                             Type first = null;
                                             var interfaces = type.GetInterfaces();
                                             if (interfaces.Length > 0) first = interfaces[0];

                                             return (first != null) ? new[] {first} : null;
                                         });
        }
    }
}