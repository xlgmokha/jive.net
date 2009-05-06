using Gorilla.Commons.Utility.Core;

namespace Gorilla.Commons.Infrastructure
{
    public interface ICallbackCommand<T> : IParameterizedCommand<ICallback<T>>
    {
    }
}