using Microsoft.EntityFrameworkCore;
using Sprint4.CSharp.WebApi.Models;

namespace Sprint4.CSharp.WebApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Product> Products => Set<Product>();
        public DbSet<Category> Categories => Set<Category>();
    }

    public static class Seed
    {
        public static void SeedData(AppDbContext db)
        {
            if (!db.Categories.Any())
            {
                var a = new Category { Name = "Eletrônicos" };
                var b = new Category { Name = "Livros" };
                db.Categories.AddRange(a,b);
                db.Products.AddRange(
                    new Product { Name = "Headset", Price = 189.9m, Category = a },
                    new Product { Name = "Teclado", Price = 120m, Category = a },
                    new Product { Name = "Romance", Price = 39.9m, Category = b }
                );
                db.SaveChanges();
            }
        }
    }
}
