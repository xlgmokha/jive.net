using System;

namespace specs
{
    static public class call
    {
        static public Action to(Action action)
        {
            return action;
        }
    }
}