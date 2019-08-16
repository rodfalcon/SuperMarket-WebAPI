using System;
using System.Threading.Tasks;
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

            builder.Entity<Products>().HasData(
                new Products
                {
                    Id = 111,
                    Name = "Gudang",
                    QuantityInPackage = 15,
                    UnitOfMeasurement = EUnitOfMeasurement.Unity,
                    CategoryId = 111,
                },

                 new Products
                {
                    Id = 112,
                    Name = "Pipe",
                    QuantityInPackage = 1,
                    UnitOfMeasurement = EUnitOfMeasurement.Unity,
                    CategoryId = 112,
                },

                new Products
                {
                    Id = 113,
                    Name = "Tobacco",
                    QuantityInPackage = 20,
                    UnitOfMeasurement = EUnitOfMeasurement.Gram,
                    CategoryId = 113,
                },

                new Products
                {
                    Id = 114,
                    Name = "Jedi Kush",
                    QuantityInPackage = 2,
                    UnitOfMeasurement = EUnitOfMeasurement.Kilogram,
                    CategoryId = 114,
                },

                new Products
                {
                    Id = 115,
                    Name = "Cachaça",
                    QuantityInPackage = 2,
                    UnitOfMeasurement = EUnitOfMeasurement.Liter,
                    CategoryId = 115,
                }
            );
        }

    }
}