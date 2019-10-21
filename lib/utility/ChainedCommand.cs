namespace jive.utility
{
  public class ChainedCommand : Command
  {
    readonly Command left;
    readonly Command right;

    public ChainedCommand(Command left, Command right)
    {
      this.left = left;
      this.right = right;
    }

    public void run()
    {
      left.run();
      right.run();
    }
  }
}
