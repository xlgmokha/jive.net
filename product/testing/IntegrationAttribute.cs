using MbUnit.Framework;

namespace Gorilla.Commons.Testing
{
    public class IntegrationAttribute : FixtureCategoryAttribute
    {
        public IntegrationAttribute() : base("Integration")
        {
        }
    }
}