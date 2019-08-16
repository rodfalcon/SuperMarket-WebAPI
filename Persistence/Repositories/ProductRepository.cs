using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Supermercado.Domain.Models;
using Supermercado.Domain.Repositories;
using Supermercado.Persistence.Contexts;

namespace Supermercado.Persistence.Repositories
{
    public class ProductRepository : BaseRepository, IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context)
        {}

        public async Task<IEnumerable<Products>> ListAsync()
        {
            return await _context.Products.Include(p => p.Category).ToListAsync();
        }
    }
}