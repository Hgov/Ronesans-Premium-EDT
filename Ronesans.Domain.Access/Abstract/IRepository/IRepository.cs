using System;
using System.Collections.Generic;

namespace Ronesans.Domain.Access.Abstract.IRepository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity GetByID(int id);
        IEnumerable<TEntity> GetAll();
        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);
        void Remove(int id);
        void RemoveRange(IEnumerable<TEntity> entities);
        void update(TEntity entity);
        int Count();

    }
}
