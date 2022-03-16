using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RepositoryPattern.Core.IRepositories;
using RepositoryPattern.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RepositoryPattern.Core.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        //we are able to use application db context through dependency injection we configure on start up class.
        protected ApplicationDbContext _context;
        protected DbSet<T> _dbSet;
        protected ILogger _logger;

        public GenericRepository(ApplicationDbContext context, ILogger logger)
        {
            _context = context;
            _logger = logger;
            _dbSet = context.Set<T>();
        }

        public virtual async Task<IEnumerable<T>> All()
        {
            return await _dbSet.ToListAsync();
        }
        public virtual async Task<bool> Add(T entity)
        {
            await _dbSet.AddAsync(entity);
            return true;
        }

        public virtual Task<bool> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<T> GetById(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        public virtual Task<bool> Upsert(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
