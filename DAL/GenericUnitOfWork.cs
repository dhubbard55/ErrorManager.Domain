using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity;
using System.Data;
using System.Collections.ObjectModel;
using ErrorManager.Domain.DAL.Interfaces;

namespace ErrorManager.Domain.DAL
{
    public class GenericUnitOfWork : IGenericUnitOfWork, IDisposable
    {
        protected readonly DbContext Context;
        protected readonly Dictionary<string, object> Repositories = new Dictionary<string, object>();

        public GenericUnitOfWork(string connection)
        {
            if (string.IsNullOrEmpty(connection))
                throw new ArgumentNullException("connection");

            Context = new DbContext(connection);
        }

        protected GenericUnitOfWork(DbContext context)
        {
            if (context == null)
                throw new ArgumentNullException("context");

            Context = context;
        }

        public virtual IGenericRepository<TEntity> Set<TEntity>() where TEntity : class
        {
            if (!Repositories.ContainsKey(typeof(TEntity).Name))
            {
                Repositories.Add(typeof(TEntity).Name, new GenericRepository<TEntity>(Context));
            }

            return (GenericRepository<TEntity>)Repositories[typeof(TEntity).Name];
        }

        public virtual ObservableCollection<TEntity> Local<TEntity>() where TEntity : class
        {
            return Context.Set<TEntity>().Local;
        }

        public virtual int Commit()
        {
            return Context.SaveChanges();
        }

        public virtual EntityState State(object entity)
        {
            return Context.Entry(entity).State;
        }

        public virtual bool IsPropertyModified(object entity, string property)
        {
            return Context.Entry(entity).Property(property).IsModified;
        }
        
        public virtual void RunStoredProcedure(string procedure, string parameters)
        {
            Context.Database.ExecuteSqlCommand("EXECUTE PROCEDURE " + procedure + "(" + parameters + ") ");
        }

        public virtual int ExecuteSqlCommand(string sql, params object[] parameters)
        {
            return Context.Database.ExecuteSqlCommand(sql, parameters);
        }

        public virtual IEnumerable<TElement> SqlQuery<TElement>(string sql, params object[] parameters)
        {
            return Context.Database.SqlQuery<TElement>(sql, parameters);
        }

        public void SetTimeout(int? timeout)
        {
            ((IObjectContextAdapter) Context).ObjectContext.CommandTimeout = timeout;
        }

        public DbContextConfiguration DbContextConfiguration
        {
            get { return Context.Configuration; }
        }

        public DbChangeTracker ChangeTracker
        {
            get { return Context.ChangeTracker; }
        }

        private Boolean _disposedValue;

        protected virtual void Dispose(Boolean disposing)
        {
            if(!_disposedValue && disposing && Context != null)
            {
                Context.Dispose();
            }
            _disposedValue = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);          
        }
    }
}