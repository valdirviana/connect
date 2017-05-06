using Dapper;
using System.Collections.Generic;
using System.Data;

namespace ConnectAPI.Repository.Base
{
    public abstract class BaseRepository
    {
        protected IReadOnlyDictionary<string, string> SearchDictionary;

        protected IDbConnection Connection { get; }
        protected IDbTransaction Transaction { get; set; }

        protected BaseRepository(IDbConnection connection, IDbTransaction transaction)
        {
            Connection = connection;
            Transaction = transaction;
        }

        protected abstract SqlBuilder.Template GetTemplateSelect(ref SqlBuilder builder);
    }
}
