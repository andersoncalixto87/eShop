using eShop.ProductApi.Models;
using Microsoft.EntityFrameworkCore;

namespace eShop.ProductApi.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options){}

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }


        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Product>().HasKey(p => p.Id);
            mb.Entity<Product>().Property(p=>p.Name).HasMaxLength(255).IsRequired();
            mb.Entity<Product>().Property(p => p.Description).HasMaxLength(255).IsRequired();
            mb.Entity<Product>().Property(p => p.Price).HasPrecision(12,2).IsRequired();
            mb.Entity<Product>().Property(p => p.ImageURL).HasMaxLength(255).IsRequired();

            mb.Entity<Category>().HasKey(p => p.Id);
            mb.Entity<Category>().Property(p => p.Name).HasMaxLength(255).IsRequired();

            mb.Entity<Category>().HasMany(g=> g.Products).WithOne(g=>g.Category).IsRequired().OnDelete(DeleteBehavior.Cascade);

            mb.Entity<Category>().HasData(new Category{ Id = 1, Name = "Material Escolar" });
            mb.Entity<Category>().HasData(new Category{ Id = 2, Name = "Acessórios" });

            mb.Entity<Product>().HasData(new Product{ Id = 1, Name = "Caderno", Description = "Caderno de desenho", Price = 12.99M, CategoryId = 1, Stock = 10,ImageURL="caderno.jpg" });
            mb.Entity<Product>().HasData(new Product { Id = 2, Name = "Caneta Azul", Description = "Caneta esferografica", Price = 3.99M, CategoryId = 1, Stock = 10, ImageURL = "caneta-azul.jpg" });
        }
    }
}
