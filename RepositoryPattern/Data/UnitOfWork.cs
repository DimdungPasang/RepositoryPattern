using Microsoft.Extensions.Logging;
using RepositoryPattern.Core.IConfiguration;
using RepositoryPattern.Core.IRepositories;
using RepositoryPattern.Core.Repositories;
using System;
using System.Threading.Tasks;

namespace RepositoryPattern.Data
{
    public class UnitOfWork: IUnitOfWork, IDisposable
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger _logger;

        public IUserRepository Users { get; set; }

        public UnitOfWork(ApplicationDbContext context, ILoggerFactory loggerFactory)
        {
            _context = context;
            _logger = loggerFactory.CreateLogger("logs");

            Users = new UserRepository(_context, _logger);
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
