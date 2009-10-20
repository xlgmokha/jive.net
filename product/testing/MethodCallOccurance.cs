using System;
using Rhino.Mocks;

namespace Gorilla.Commons.Testing
{
    public class MethodCallOccurance<T> : IHideObjectMembers
    {
        readonly Action<T> action;
        readonly T mock;

        public MethodCallOccurance(T mock, Action<T> action)
        {
            this.action = action;
            this.mock = mock;
            mock.AssertWasCalled(action);
        }

        public void times(int number_of_times_the_method_should_have_been_called)
        {
            mock.AssertWasCalled(action, y => y.Repeat.Times(number_of_times_the_method_should_have_been_called));
        }

        public void only_once()
        {
            times(1);
        }

        public void twice()
        {
            times(2);
        }
    }
}