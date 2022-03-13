using RepositoryPattern.Core.IRepositories;
using System.Threading.Tasks;

namespace RepositoryPattern.Core.IConfiguration
{
    public interface IUnitOfWork
    {
        IUserRepository Users { get; set; }
        Task CompleteAsync();
    }
}
