using Microsoft.EntityFrameworkCore;
using Order.Core.Entities;
using Order.Core.Repositories;
using Order.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Order.Infrastructure.Repositories
{
    public class RepositoryBase<T> : IAsyncRepository<T> where T : EntityBase
    {
        private readonly OrderDbContext _dbContext;

        public RepositoryBase(OrderDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<IReadOnlyList<T>> GetAllAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbContext.Set<T>().Where(predicate).ToListAsync();
        }

        public async Task<T?> GetByIdAsync(int id)
        {
           var entity =  await _dbContext.Set<T>().FirstOrDefaultAsync(p=>p.Id == id);
            return entity;
        }

        public async Task<T> AddAsync(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }
        public async Task UpdateAsync(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.Set<T>().Update(entity);
            await _dbContext.SaveChangesAsync();
        }


        public async Task DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

    }
}
