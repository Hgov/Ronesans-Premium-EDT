using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ronesans.Domain.Access.Abstract.IRepository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity GetByID(int id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task AddAsync(TEntity entity);
        Task AddRangeAsync(IEnumerable<TEntity> entities);
        void RemoveAsync(int id);
        void RemoveRange(IEnumerable<TEntity> entities);
        void update(TEntity entity);
        Task<int> CountAsync();

    }
}
