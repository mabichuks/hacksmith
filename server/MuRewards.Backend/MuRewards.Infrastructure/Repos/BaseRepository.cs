using Microsoft.EntityFrameworkCore;
using MuRewards.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MuRewards.Infrastructure.Repos
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext _context;

        public BaseRepository(DbContext context)
        {
            _context = context;
        }
        public void Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            _context.Set<TEntity>().AddRange(entities);
        }

        public IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {

            return _context.Set<TEntity>().Where(predicate);
        }

        public bool Any(Expression<Func<TEntity, bool>> predicate)
        {
            return _context.Set<TEntity>().Any(predicate);
        }

        public TEntity Get(int id)
        {
            return _context.Set<TEntity>().Find(id);
        }

        public IQueryable<TEntity> GetAll()
        {
            return _context.Set<TEntity>();
        }

        public void Remove(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            _context.Set<TEntity>().RemoveRange(entities);
        }

        public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return _context.Set<TEntity>().SingleOrDefault(predicate);
        }

        public Task<TEntity> GetAsync(int id)
        {
            return Task.FromResult(Get(id));
        }

        public Task<IQueryable<TEntity>> GetAllAsync()
        {
            return Task.FromResult(GetAll());
        }

        public Task<IQueryable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return Task.FromResult(Find(predicate));
        }

        public Task<TEntity> SingleOrDefaultAync(Expression<Func<TEntity, bool>> predicate)
        {
            return Task.FromResult(SingleOrDefault(predicate));
        }

        public void AddAsync(TEntity entity)
        {
            Task.FromResult(_context.Set<TEntity>().Add(entity));
        }

        public void RemoveAsync(TEntity entity)
        {
            Task.FromResult(_context.Set<TEntity>().Remove(entity));
        }
        public void UpdateAsync(TEntity entity)
        {
            Task.FromResult(_context.Entry(entity).State = EntityState.Modified);
        }
        public Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return Task.FromResult(Any(predicate));
        }
    }
}
