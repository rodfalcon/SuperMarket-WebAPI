using System.Collections.Generic;
using System.Threading.Tasks;
using Supermercado.Domain.Models;
using Supermercado.Domain.Services.Communication;

namespace Supermercado.Domain.Services
{
    public interface ICategoryService
    {
         Task<IEnumerable<Category>> ListAsync();
	    Task<CategoryResponse> SaveAsync(Category category);
	    Task<CategoryResponse> UpdateAsync(int id, Category category);
        Task<CategoryResponse> DeleteAsync(int id);
    }
}