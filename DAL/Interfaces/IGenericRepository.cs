using System;
using System.Collections.Generic;
using System.Linq;

namespace ErrorManager.Domain.DAL.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> Find();
        TEntity Get(params object[] keyValues);

        void Insert(TEntity entity);
        void Update(TEntity entity);
        void Update(TEntity entityToBeUpdated, TEntity entityToUpdate);
        void Delete(params object[] keyValues);
        void Delete(TEntity entity);
        int Commit();
    }
}
