using Microsoft.AspNetCore.Mvc;
using WebApi.DBOperations;

namespace WebApi.Controllers{

    [ApiController]
    [Route("[controller]s")]

    public class ProductController: ControllerBase{

        private readonly ProductsDbContext _context;

        public ProductController(ProductsDbContext context)
        {
            _context=context;
        }



        [HttpGet]
        public IActionResult GetProducts()
        {
            var productList = _context.Products.OrderBy(x=>x.Id).ToList<Product>();
            return Ok(productList);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
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
            var product = _context.Products.SingleOrDefault(x=>x.Name==newProduct.Name);

            if(product is not null){
                return Conflict("A product with the same name already exists.");

            }

            _context.Products.Add(newProduct);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = newProduct.Id }, newProduct);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, [FromBody] Product updatedProduct)
        {
            var product = _context.Products.SingleOrDefault(x=>x.Id==id);

            if(product is null){
                return NotFound();
            }

            product.Name = updatedProduct.Name != "string" ? updatedProduct.Name : product.Name;
            product.Price = updatedProduct.Price != default ? updatedProduct.Price : product.Price;
            product.Description = updatedProduct.Description != "string" ? updatedProduct.Description : product.Description;
            product.Category = updatedProduct.Category != "string" ? updatedProduct.Category : product.Category;

            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var product = _context.Products.SingleOrDefault(x=>x.Id==id);
            if(product is null){
                return NotFound();
            }

            _context.Products.Remove(product);
            _context.SaveChanges();
            return Ok();
        }


        [HttpPatch("{id}")]
        public IActionResult PartialUpdateProduct(int id, [FromBody] Product updatedProduct)
        {
            var product = _context.Products.FirstOrDefault(x=>x.Id==id);
            if(product is null){
                return NotFound();
            }
            
           product.Name = updatedProduct.Name != "string" ? updatedProduct.Name : product.Name;
            product.Price = updatedProduct.Price != default ? updatedProduct.Price : product.Price;
            product.Description = updatedProduct.Description != "string" ? updatedProduct.Description : product.Description;
            product.Category = updatedProduct.Category != "string" ? updatedProduct.Category : product.Category;

            _context.SaveChanges();
            return Ok();

        }

    }
}