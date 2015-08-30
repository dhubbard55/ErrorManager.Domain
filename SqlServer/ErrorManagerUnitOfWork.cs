using ErrorManager.Domain.DAL;
using System.Data.Common;

namespace ErrorManager.Domain.SqlServer
{
    public class ErrorManagerUnitOfWork : GenericUnitOfWork, IErrorManagerUnitOfWork
    {
        public ErrorManagerUnitOfWork(DbConnection connection, bool contextOwnsConnection)
            : base(new ErrorManagerContext(connection, contextOwnsConnection))
        {
        }

        public ErrorManagerUnitOfWork(string connection) 
            : base(connection)
        {
        }
    }
}


