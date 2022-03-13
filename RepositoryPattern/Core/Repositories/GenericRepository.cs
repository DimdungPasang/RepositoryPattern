using RepositoryPattern.Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RepositoryPattern.Core.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {

        public Task<bool> Add(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> All()
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<T> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Upsert(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
