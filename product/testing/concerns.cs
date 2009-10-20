using developwithpassion.bdd.mbunit.standard.observations;
using Rhino.Mocks;

namespace Gorilla.Commons.Testing
{
    public abstract class concerns_for<Contract> : observations_for_a_sut_without_a_contract<Contract>,
                                                   IHideObjectMembers
    {
        protected static T when_the<T>(T item)
        {
            return item;
        }
    }

    public abstract class concerns_for<Contract, Implementation> :
        observations_for_a_sut_with_a_contract<Contract, Implementation>, IHideObjectMembers
        where Implementation : Contract
    {
        protected static T when_the<T>(T item)
        {
            return item;
        }

        protected static T dependency<T>() where T : class
        {
            return MockRepository.GenerateMock<T>();
        }
    }

    public abstract class concerns : observations_for_a_static_sut, IHideObjectMembers
    {
        protected static T dependency<T>() where T : class
        {
            return MockRepository.GenerateMock<T>();
        }

        static protected T when_the<T>(T item)
        {
            return item;
        }
    }
}