using System;

namespace Gorilla.Commons.Testing
{
    public class ConcernAttribute : bdddoc.core.ConcernAttribute
    {
        public ConcernAttribute(Type concern) : base(concern)
        {
        }
    }
}