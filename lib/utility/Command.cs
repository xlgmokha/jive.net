namespace jive.utility
{
  public interface Command
  {
    void run();
  }

  public interface Command<in T>
  {
    void run(T item);
  }
}
