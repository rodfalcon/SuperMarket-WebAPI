using System.Collections.Generic;
using System.Threading.Tasks;
using Supermercado.Domain.Models;
using Supermercado.Domain.Repositories;
using Supermercado.Domain.Services;

namespace Supermercado.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            this._categoryRepository = categoryRepository;
        }
        public async Task<IEnumerable<Category>> ListAsync()
        {
            return await _categoryRepository.ListAsync();
        }
    }
}