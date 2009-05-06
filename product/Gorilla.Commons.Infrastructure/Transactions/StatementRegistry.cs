using System;
using Gorilla.Commons.Infrastructure.Logging;
using Gorilla.Commons.Utility.Core;

namespace Gorilla.Commons.Infrastructure.Transactions
{
    public class StatementRegistry : IStatementRegistry
    {
        public IStatement prepare_delete_statement_for<T>(T entity) where T : IIdentifiable<Guid>
        {
            return new DeletionStatement<T>(entity);
        }

        public IStatement prepare_command_for<T>(T entity) where T : IIdentifiable<Guid>
        {
            return new SaveOrUpdateStatement<T>(entity);
        }
    }

    public class SaveOrUpdateStatement<T> : IStatement where T : IIdentifiable<Guid>
    {
        readonly T entity;

        public SaveOrUpdateStatement(T entity)
        {
            this.entity = entity;
        }

        public void prepare(IDatabaseConnection connection)
        {
            connection.store(entity);
            this.log().debug("saving: {0}", entity);
        }
    }

    public class DeletionStatement<T> : IStatement
    {
        readonly T entity;

        public DeletionStatement(T entity)
        {
            this.entity = entity;
        }

        public void prepare(IDatabaseConnection connection)
        {
            connection.delete(entity);
        }
    }
}