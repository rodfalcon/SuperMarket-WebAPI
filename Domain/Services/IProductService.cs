using System.Collections.Generic;
using System.Threading.Tasks;
using Supermercado.Domain.Models;

namespace Supermercado.Domain.Services
{
    public interface IProductService
    {
         Task<IEnumerable<Products>> ListAsync();
    }
}