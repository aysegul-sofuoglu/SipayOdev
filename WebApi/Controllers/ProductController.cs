using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.DBOperations;
using WebApi.ProductOperations.CreateProduct;
using WebApi.ProductOperations.DeleteProduct;
using WebApi.ProductOperations.GetProductDetail;
using WebApi.ProductOperations.GetProducts;
using WebApi.ProductOperations.UpdateProduct;
using static WebApi.ProductOperations.CreateProduct.CreateProductCommand;
using static WebApi.ProductOperations.GetProductDetail.GetProductDetailQuery;
using static WebApi.ProductOperations.UpdateProduct.UpdateProductCommand;

namespace WebApi.Controllers{

    //[Authorize]
    [ApiController]
    [Route("[controller]s")]

    public class ProductController: ControllerBase{

        private readonly ProductsDbContext _context;
        private readonly IMapper _mapper;

        public ProductController(ProductsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }



        [HttpGet]
        public IActionResult GetProducts()
        {
           GetProductsQuery query =new GetProductsQuery(_context, _mapper);
           var result = query.Handle();
           return Ok(result);
        }


        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            ProductDetailViewModel result;
           
                GetProductDetailQuery query = new GetProductDetailQuery(_context, _mapper);
                query.ProductId = id;
                GetProductDetailQueryValidator validator = new GetProductDetailQueryValidator();
                validator.ValidateAndThrow(query);

                result = query.Handle();
            
            
            return Ok(result);
        }

        // [HttpGet]
        // public Product Get([FromQuery] string id)
        // {
        //     var product = ProductList.Where(product=>product.Id==Convert.ToInt32(id)).SingleOrDefault();
        //     return product;
        // }


        [HttpPost]
        public IActionResult AddProduct([FromBody] CreateProductModel newProduct)
        {
            CreateProductCommand command = new CreateProductCommand(_context, _mapper);
            
                command.Model = newProduct;
                CreateProductCommandValidator validator = new CreateProductCommandValidator();
                validator.ValidateAndThrow(command);
                command.Handle();

                // if(!result.IsValid)
                // foreach(var item in result.Errors)
                //     Console.WriteLine("Property " + item.PropertyName + " - Error Message: " + item.ErrorMessage);
                
                // else
                // command.Handle();
                
                
            

            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, [FromBody] UpdateProductModel updatedProduct)
        {
            
                UpdateProductCommand command = new UpdateProductCommand(_context);
                command.ProductId = id;
                command.Model = updatedProduct;

                UpdateProductCommandValidator validator = new UpdateProductCommandValidator();
                validator.ValidateAndThrow(command);

                command.Handle();
           
                return Ok();
            
            
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
                DeleteProductCommand command = new DeleteProductCommand(_context);
                command.ProductId = id;
                DeleteProductCommandValidator validator = new DeleteProductCommandValidator();
                validator.ValidateAndThrow(command);
                command.Handle();
           
            
            return Ok();
        }


        // [HttpPatch("{id}")]
        // public IActionResult PartialUpdateProduct(int id, [FromBody] Product updatedProduct)
        // {
        //     var product = _context.Products.FirstOrDefault(x=>x.Id==id);
        //     if(product is null){
        //         return NotFound();
        //     }
            
        //    product.Name = updatedProduct.Name != "string" ? updatedProduct.Name : product.Name;
        //     product.Price = updatedProduct.Price != default ? updatedProduct.Price : product.Price;
        //     product.Description = updatedProduct.Description != "string" ? updatedProduct.Description : product.Description;
        //     product.CategoryId = updatedProduct.CategoryId != default ? updatedProduct.CategoryId : product.CategoryId;

        //     _context.SaveChanges();
        //     return Ok();

        // }

    }
}