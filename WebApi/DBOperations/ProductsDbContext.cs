using Microsoft.EntityFrameworkCore;

namespace WebApi.DBOperations
{
    public class ProductsDbContext : DbContext
    {
        public ProductsDbContext(DbContextOptions<ProductsDbContext>options) : base(options)
        { }
        public DbSet<Product> Products{ get; set; }
    }
}