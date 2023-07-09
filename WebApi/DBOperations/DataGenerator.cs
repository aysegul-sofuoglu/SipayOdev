
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace WebApi.DBOperations

{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ProductsDbContext(serviceProvider.GetRequiredService<DbContextOptions<ProductsDbContext>>()))
            {
                if(context.Products.Any())
                {
                    return;
                }

                context.Products.AddRange(
                    new Product { Name = "Laptop", Price = 1500, Description = "Powerful laptop for professional use", Category = "Electronics" },
                    new Product { Name = "Mouse", Price = 20, Description = "Wireless mouse for comfortable navigation", Category = "Electronics" },
                    new Product { Name = "Telephone", Price = 200, Description = "Smartphone with advanced features", Category = "Electronics" },
                    new Product { Name = "Watch", Price = 100, Description = "Stylish wristwatch for any occasion", Category = "Fashion" },
                    new Product { Name = "Microphone", Price = 80, Description = "High-quality microphone for audio recording", Category = "Electronics" },
                    new Product { Name = "Hair Dryer", Price = 40, Description = "Fast and efficient hair drying", Category = "Home Appliances" },
                    new Product { Name = "Charger", Price = 15, Description = "Universal charger for various devices", Category = "Electronics" },
                    new Product { Name = "Backpack", Price = 50, Description = "Spacious backpack for daily use", Category = "Fashion" },
                    new Product { Name = "Thermos", Price = 25, Description = "Insulated thermos for keeping beverages hot or cold", Category = "Home Appliances" },
                    new Product { Name = "Printer", Price = 120, Description = "High-resolution printer for professional printing", Category = "Electronics" }

                );

                context.SaveChanges();
            }
        }
    }
}