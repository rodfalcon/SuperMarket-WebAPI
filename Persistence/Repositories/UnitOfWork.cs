using System.Threading.Tasks;
using Supermercado.Domain.Repositories;
using Supermercado.Persistence.Contexts;

namespace Supermercado.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }
        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}