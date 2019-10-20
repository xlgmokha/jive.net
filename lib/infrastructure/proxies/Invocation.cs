using System.Reflection;

namespace gorilla.infrastructure.proxies
{
    public interface Invocation
    {
        void proceed();
        object[] arguments { get; }
        MethodInfo method { get; }
        object return_value { get; set; }
    }
}