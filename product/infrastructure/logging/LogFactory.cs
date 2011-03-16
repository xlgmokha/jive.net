using System;

namespace gorilla.infrastructure.logging
{
    public interface LogFactory
    {
        Logger create_for(Type type_to_create_logger_for);
    }
}