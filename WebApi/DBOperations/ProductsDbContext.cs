using Microsoft.EntityFrameworkCore;
using WebApi.Entities;

namespace WebApi.DBOperations
{
    public class ProductsDbContext : DbContext
    {
        public ProductsDbContext(DbContextOptions<ProductsDbContext>options) : base(options)
        { }
        public DbSet<Product> Products{ get; set; }
        public DbSet<User> Users{ get; set; }
    }
}