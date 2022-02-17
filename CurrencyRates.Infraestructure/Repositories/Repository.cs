using CurrencyRates.Domain.Interfaces.Repositories;
using CurrencyRates.Domain.Models;
using CurrencyRates.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CurrencyRates.Infraestructure.Repositories
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity, new()
    {
        protected readonly DataBaseContext _databaseContext;
        protected readonly DbSet<TEntity> _dbSet;

        protected Repository(DataBaseContext databaseContext)
        {
            _databaseContext = databaseContext;
            _dbSet = databaseContext.Set<TEntity>(); 
        }

        public async Task<IEnumerable<TEntity>> Get(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.AsNoTracking().Where(predicate).ToListAsync();
        }

        public virtual async Task<TEntity> GetById(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        public virtual async Task<List<TEntity>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public virtual async Task Add(TEntity entity)
        {
            _dbSet.Add(entity);
            await SaveChanges();
        }

        public virtual async Task Update(TEntity entity)
        {
            _dbSet.Update(entity);
            await SaveChanges();
        }

        public virtual async Task Delete(Guid id)
        {
            _dbSet.Remove(new TEntity { Id = id });
            await SaveChanges();
        }

        public async Task<int> SaveChanges()
        {
            return await _databaseContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _databaseContext?.Dispose();
        }
    }
}
