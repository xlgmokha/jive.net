using System;

namespace Gorilla.Commons.Infrastructure.Logging
{
    public interface ILogFactory
    {
        ILogger create_for(Type type_to_create_logger_for);
    }
}