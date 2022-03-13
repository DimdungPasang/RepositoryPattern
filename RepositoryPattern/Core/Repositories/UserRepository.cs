using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RepositoryPattern.Core.IRepositories;
using RepositoryPattern.Data;
using RepositoryPattern.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepositoryPattern.Core.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        //we need to pass arguments context and logger to UserRepository class's constructor
        //because base class ie. GenericRepository class is expecting them so it can initialize its fields.
        public UserRepository(ApplicationDbContext context, ILogger logger) : base(context, logger)
        {
        }

        public override async Task<IEnumerable<User>> All()
        {
            try
            {
                return await _dbSet.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} All Method Error", typeof(UserRepository));
                return new List<User>();
            }
        }


        public override async Task<bool> Upsert(User entity)
        {

            try
            {
                //check if there is existing user
                var existingUser = await _dbSet.Where(x => x.Id == entity.Id).FirstOrDefaultAsync();

                //if there is no user found then add them to db
                if (existingUser == null)
                {
                    return await Add(entity);
                }

                //else update there values
                existingUser.FirstName = entity.FirstName;
                existingUser.LastName = entity.LastName;
                existingUser.Email = entity.Email;

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} Upset Method Error", typeof(UserRepository));
                return false;
            }
        }

    }
}
