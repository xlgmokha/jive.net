using System;
using System.Collections.Generic;

namespace Gorilla.Commons.Infrastructure.Reflection
{
    public class ApplicationAssembly : Assembly
    {
        readonly System.Reflection.Assembly assembly;

        public ApplicationAssembly(System.Reflection.Assembly assembly)
        {
            this.assembly = assembly;
        }

        public IEnumerable<Type> all_types()
        {
            return assembly.GetTypes();
        }
    }
}