namespace jive.infrastructure.proxies
{
  public interface Interceptor
  {
    void intercept(Invocation invocation);
  }
}
