using System.Collections.Generic;
using System.Threading.Tasks;
using Supermercado.Domain.Models;

namespace Supermercado.Domain.Repositories
{
    public interface IProductRepository
    {
         Task<IEnumerable<Products>> ListAsync();
    }
}