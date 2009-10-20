using System;

namespace Gorilla.Commons.Infrastructure.Container
{
    static public class Resolve
    {
        static DependencyRegistry underlying_registry;
        static bool initialized;

        static public void initialize_with(DependencyRegistry registry)
        {
            underlying_registry = registry;
            initialized = registry != null;
        }

        static public DependencyToResolve the<DependencyToResolve>()
        {
            try
            {
                return underlying_registry.get_a<DependencyToResolve>();
            }
            catch (Exception e)
            {
                throw new DependencyResolutionException<DependencyToResolve>(e);
            }
        }

        static public bool is_initialized()
        {
            return initialized;
        }
    }
}