using ErrorManager.Domain.DAL;
using System.Data.Common;
using System.Data.SqlClient;

namespace ErrorManager.Domain.SqlServer
{
    public class ErrorManagerUnitOfWork : GenericUnitOfWork, IErrorManagerUnitOfWork
    {
        public ErrorManagerUnitOfWork(DbConnection connection, bool contextOwnsConnection)
            : base(new ErrorManagerContext(connection, contextOwnsConnection))
        {
        }

        public ErrorManagerUnitOfWork(string connection) 
            : this(new SqlConnection(connection),true)
        {
        }
    }
}


