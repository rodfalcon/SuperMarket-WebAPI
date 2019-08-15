using System.Threading.Tasks;

namespace Supermercado.Domain.Repositories
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}