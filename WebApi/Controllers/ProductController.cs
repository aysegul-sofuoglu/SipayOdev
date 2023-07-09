using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers{

    [ApiController]
    [Route("[controller]s")]

    public class ProductController: ControllerBase{

        private static List<Product> ProductList = new List<Product>()
        {
            new Product { Id = 1, Name = "Laptop", Price = 1500, Description = "Powerful laptop for professional use", Category = "Electronics" },
            new Product { Id = 2, Name = "Mouse", Price = 20, Description = "Wireless mouse for comfortable navigation", Category = "Electronics" },
            new Product { Id = 3, Name = "Telephone", Price = 200, Description = "Smartphone with advanced features", Category = "Electronics" },
            new Product { Id = 4, Name = "Watch", Price = 100, Description = "Stylish wristwatch for any occasion", Category = "Fashion" },
            new Product { Id = 5, Name = "Microphone", Price = 80, Description = "High-quality microphone for audio recording", Category = "Electronics" },
            new Product { Id = 6, Name = "Hair Dryer", Price = 40, Description = "Fast and efficient hair drying", Category = "Home Appliances" },
            new Product { Id = 7, Name = "Charger", Price = 15, Description = "Universal charger for various devices", Category = "Electronics" },
            new Product { Id = 8, Name = "Backpack", Price = 50, Description = "Spacious backpack for daily use", Category = "Fashion" },
            new Product { Id = 9, Name = "Thermos", Price = 25, Description = "Insulated thermos for keeping beverages hot or cold", Category = "Home Appliances" },
            new Product { Id = 10, Name = "Printer", Price = 120, Description = "High-resolution printer for professional printing", Category = "Electronics" }
        };


        [HttpGet]
        public List<Product> GetProducts()
        {
            var productList = ProductList.OrderBy(x=>x.Id).ToList<Product>();
            return productList;
        }

        [HttpGet("{id}")]
        public Product GetById(int id)
        {
            var product = ProductList.Where(product=>product.Id==id).SingleOrDefault();
            return product;
        }

        // [HttpGet]
        // public Product Get([FromQuery] string id)
        // {
        //     var product = ProductList.Where(product=>product.Id==Convert.ToInt32(id)).SingleOrDefault();
        //     return product;
        // }


        [HttpPost]
        public IActionResult AddProduct([FromBody] Product newProduct)
        {
            var product = ProductList.SingleOrDefault(x=>x.Name==newProduct.Name);

            if(product is not null){
                return BadRequest();

            }

            ProductList.Add(newProduct);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, [FromBody] Product updatedProduct)
        {
            var product = ProductList.SingleOrDefault(x=>x.Id==id);

            if(product is null){
                return BadRequest();
            }

            product.Name = updatedProduct.Name != default ? updatedProduct.Name : product.Name;
            product.Price = updatedProduct.Price != default ? updatedProduct.Price : product.Price;
            product.Description = updatedProduct.Description != default ? updatedProduct.Description : product.Description;
            product.Category = updatedProduct.Category != default ? updatedProduct.Category : product.Category;

            return Ok();
        }

    }
}