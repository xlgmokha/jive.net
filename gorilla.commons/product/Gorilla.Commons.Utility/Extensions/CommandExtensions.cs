using System;
using Gorilla.Commons.Utility.Core;

namespace Gorilla.Commons.Utility.Extensions
{
    static public class CommandExtensions
    {
        static public ICommand then<Command>(this ICommand left) where Command : ICommand, new()
        {
            return then(left, new Command());
        }

        static public ICommand then(this ICommand left, ICommand right)
        {
            return new ChainedCommand(left, right);
        }

        static public ICommand then(this ICommand left, Action right)
        {
            return new ChainedCommand(left, new ActionCommand(right));
        }
    }
}