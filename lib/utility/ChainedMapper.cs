namespace gorilla.utility
{
    public class ChainedMapper<Left, Middle, Right> : Mapper<Left, Right>
    {
        readonly Mapper<Left, Middle> left;
        readonly Mapper<Middle, Right> right;

        public ChainedMapper(Mapper<Left, Middle> left, Mapper<Middle, Right> right)
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