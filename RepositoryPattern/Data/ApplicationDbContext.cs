using Microsoft.EntityFrameworkCore;
using RepositoryPattern.Models;

namespace RepositoryPattern.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            :base(options)
        {

        }

        //this dbset prop tells efcore to create a table if it doesn't exist. 
        public virtual DbSet<User> User { get; set; }
    }
}
