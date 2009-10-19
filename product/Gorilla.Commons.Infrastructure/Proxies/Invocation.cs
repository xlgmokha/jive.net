using System.Reflection;

namespace Gorilla.Commons.Infrastructure.Proxies
{
    public interface Invocation
    {
        void proceed();
        object[] arguments { get; }
        MethodInfo method { get; }
        object return_value { get; set; }
    }
}