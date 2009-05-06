namespace Gorilla.Commons.Utility.Core
{
    public class ChainedCommand : ICommand
    {
        private readonly ICommand left;
        private readonly ICommand right;

        public ChainedCommand(ICommand left, ICommand right)
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