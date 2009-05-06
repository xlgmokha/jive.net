using System;

namespace Gorilla.Commons.Utility.Core
{
    public class FuncSpecification<T> : ISpecification<T>
    {
        Func<T, bool> condition;

        public FuncSpecification(Func<T, bool> condition)
        {
            this.condition = condition;
        }

        public bool is_satisfied_by(T item)
        {
            return condition(item);
        }
    }
}