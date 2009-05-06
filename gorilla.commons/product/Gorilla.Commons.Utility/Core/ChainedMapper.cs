namespace Gorilla.Commons.Utility.Core
{
    public class ChainedMapper<Left, Middle, Right> : IMapper<Left, Right>
    {
        private readonly IMapper<Left, Middle> left;
        private readonly IMapper<Middle, Right> right;

        public ChainedMapper(IMapper<Left, Middle> left, IMapper<Middle, Right> right)
        {
            this.left = left;
            this.right = right;
        }

        public Right map_from(Left item)
        {
            return right.map_from(left.map_from(item));
        }
    }
}