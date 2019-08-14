using System.Collections.Generic;
using System.Threading.Tasks;
using Supermercado.Domain.Models;

namespace Supermercado.Domain.Repositories
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> ListAsync();
    }
}