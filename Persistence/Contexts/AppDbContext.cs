using Microsoft.EntityFrameworkCore;
using Supermercado.Domain.Models;

namespace Supermercado.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Products> Products { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            builder.Entity<Category>().ToTable("Categories");
            builder.Entity<Category>().HasKey(p => p.Id);
            builder.Entity<Category>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Category>().Property(p => p.Name).IsRequired().HasMaxLength(30);
            builder.Entity<Category>().HasMany(p => p.Products).WithOne(p => p.Category).HasForeignKey(p => p.CategoryId);

            builder.Entity<Category>().HasData
            (
                new Category { Id = 420, Name = "Weed" }, // Id set manually due to in-memory provider
                new Category { Id = 421, Name = "Dairy Milk" }
            );

            builder.Entity<Products>().ToTable("Products");
            builder.Entity<Products>().HasKey(p => p.Id);
            builder.Entity<Products>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Products>().Property(p => p.Name).IsRequired().HasMaxLength(50);
            builder.Entity<Products>().Property(p => p.QuantityInPackage).IsRequired();
            builder.Entity<Products>().Property(p => p.UnitOfMeasurement).IsRequired();
        }
    }
}