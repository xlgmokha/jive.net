using System;

namespace Gorilla.Commons.Testing
{
    public class call
    {
        static public Action to(Action action)
        {
            return action;
        }
    }
}