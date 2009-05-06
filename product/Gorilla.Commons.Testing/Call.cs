using System;

namespace Gorilla.Commons.Testing
{
    public class call
    {
        public static Action to(Action action)
        {
            return action;
        }
    }
}