using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Supermercado.Domain.Models;
using Supermercado.Domain.Repositories;
using Supermercado.Persistence.Contexts;

namespace Supermercado.Persistence.Repositories
{
    public class CategoryRepository : BaseRepository, ICategoryRepository
    {
        public CategoryRepository(AppDbContext context) : base(context)
        { }       

        public async Task AddAsync(Category category)
        {
            await _context.Categories.ToListAsync();
        }

        public async Task<Category> FindByIdAsync(int id)
        {
            return await _context.Categories.FindAsync(id);
        }

        public async Task<IEnumerable<Category>> ListAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        public void Remove(Category category)
        {
            throw new System.NotImplementedException();
        }

        public void Update(Category category)
        {
            _context.Categories.Update(category);
        }
    }
}