using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Rhino.Mocks;

namespace Gorilla.Commons.Testing
{
    static public class Create
    {
        static public Stub an<Stub>() where Stub : class
        {
            return An<Stub>();
        }

        static ItemToStub An<ItemToStub>() where ItemToStub : class
        {
            var type = typeof (ItemToStub);
            if (type.IsClass)
            {
                var constructors = type.GetConstructors(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                if (constructors.Any(x => x.GetParameters().Length == 0))
                    return MockRepository.GenerateMock<ItemToStub>();

                return MockRepository.GenerateMock<ItemToStub>(get_parameters_for(get_greediest_constructor_from(constructors)).ToArray());
            }
            return MockRepository.GenerateMock<ItemToStub>();
        }

        static IEnumerable<object> get_parameters_for(ConstructorInfo constructor)
        {
            return constructor
                .GetParameters()
                .Select(x =>
                {
                    if (x.ParameterType.IsValueType)
                        return Activator.CreateInstance(x.ParameterType);
                    if (x.ParameterType.IsSealed) return null;
                    return MockRepository.GenerateStub(x.ParameterType);
                });
        }

        static ConstructorInfo get_greediest_constructor_from(IEnumerable<ConstructorInfo> constructors)
        {
            return constructors.OrderBy(x => x.GetParameters().Count()).Last();
        }

        static public T the_dependency<T>() where T : class
        {
            return An<T>();
        }
    }
}