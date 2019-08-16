using System.Collections.Generic;
using System.Threading.Tasks;
using Supermercado.Domain.Models;
using Supermercado.Domain.Repositories;
using Supermercado.Domain.Services;

namespace Supermercado.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;
    
        public ProductService(IProductRepository productRepository, ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<Products>> ListAsync()
        {
            return await _productRepository.ListAsync();
        }
    }
}