using Microsoft.EntityFrameworkCore;
using Ronesans.Domain.Access.Abstract.IRepository;
using Ronesans.Domain.Access.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ronesans.Domain.Access.Concrete.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected RonesansDbContext _Context;
        private DbSet<TEntity> _dbSet;

        public Repository(RonesansDbContext context)
        {
            this._Context = context;
            this._dbSet = _Context.Set<TEntity>();
        }
        public void Add(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            _dbSet.AddRange(entities);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _dbSet.ToList();
        }

        public TEntity GetByID(int id)
        {
            return _dbSet.Find(id);
        }
        public void Remove(int id)
        {
            _dbSet.Remove(GetByID(id));
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            _dbSet.RemoveRange(entities);
        }

        public void update(TEntity entity)
        {
            _dbSet.Attach(entity);
        }
        public int Count()
        {
            return _dbSet.Count();
        }
    }
}
