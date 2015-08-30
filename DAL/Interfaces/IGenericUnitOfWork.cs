using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity.Infrastructure;

namespace ErrorManager.Domain.DAL.Interfaces
{
    public interface IGenericUnitOfWork 
    {
        IGenericRepository<TEntity> Set<TEntity>() where TEntity : class;
        ObservableCollection<TEntity> Local<TEntity>() where TEntity : class;

        int Commit();
        int ExecuteSqlCommand(string sql, params object[] parameters);
        IEnumerable<TElement> SqlQuery<TElement>(string sql, params object[] parameters);

        [Description("Sets the connection timeout in seconds")]
        void SetTimeout(int? timeout);

        DbContextConfiguration DbContextConfiguration { get; }
        DbChangeTracker ChangeTracker { get; }
    }
}