using System;
using System.Linq;
using System.Data.Entity;
using System.Data;
using ErrorManager.Domain.DAL.Interfaces;

namespace ErrorManager.Domain.DAL
{
    /// <summary>
    /// GenericRepository wrapper for entities
    /// </summary>
    /// <typeparam name="TEntity">Model class mapped with Entity Framework</typeparam>
    public class GenericRepository<TEntity> : IDisposable, IGenericRepository<TEntity> where TEntity : class
    {
        private readonly DbContext _context;
        private readonly IDbSet<TEntity> _dbSet;

        public GenericRepository(DbContext context)
        {
            if (context == null)
                throw new ArgumentNullException("context");

            _context = context;
            
            _dbSet = context.Set<TEntity>();
        }

        public virtual IQueryable<TEntity> Find()
        {
            return _dbSet.AsQueryable();
        }

        public virtual TEntity Get(params object[] keyValues)
        {
            return _dbSet.Find(keyValues);
        }

        public virtual void Insert(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public virtual void Update(TEntity entityToUpdate)
        {
            _dbSet.Attach(entityToUpdate);
            _context.Entry(entityToUpdate).State = EntityState.Modified;
        }

        public virtual void Update(TEntity entityToBeUpdated, TEntity entityToUpdate)
        {
            var origEntity = _context.Entry(entityToBeUpdated);
            origEntity.CurrentValues.SetValues(entityToUpdate);
        }

        public int Commit()
        {
            return _context.SaveChanges();
        }

        public virtual void Delete(params object[] keyValues)
        {
            TEntity entityToDelete = _dbSet.Find(keyValues);
            Delete(entityToDelete);
        }

        public virtual void Delete(TEntity entityToDelete)
        {
            if (_context.Entry(entityToDelete).State == EntityState.Detached)
            {
                _dbSet.Attach(entityToDelete);
            }

            _dbSet.Remove(entityToDelete);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposing) return;

            if (_context != null)
            {
                _context.Dispose();
            }
        }
    }
}