using System;

namespace Gorilla.Commons.Testing
{
    static public class call
    {
        static public Action to(Action action)
        {
            return action;
        }
    }
}