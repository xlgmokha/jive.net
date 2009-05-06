using System.Reflection;

namespace Gorilla.Commons.Infrastructure.Proxies
{
    public interface IInvocation
    {
        void Proceed();
        object[] Arguments { get; }
        MethodInfo Method { get; }
        object ReturnValue { get; set; }
    }
}