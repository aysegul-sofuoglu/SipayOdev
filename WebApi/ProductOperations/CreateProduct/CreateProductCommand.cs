using AutoMapper;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.ProductOperations.CreateProduct{

    public class CreateProductCommand
    {
        public CreateProductModel Model { get; set; }

        private readonly ProductsDbContext _dbContext;
        private readonly IMapper _mapper;
        public CreateProductCommand(ProductsDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper; 
        }

        public void Handle()
        {
            var product = _dbContext.Products.SingleOrDefault(x=>x.Name==Model.Name);

            if(product is not null){
                throw new InvalidOperationException("A product with the same name already exists.");
            }
            product =_mapper.Map<Product>(Model); 
            //new Product();
            // product.Name = Model.Name;
            // product.Price = Model.Price;
            // product.Description = Model.Description;
            // product.CategoryId = Model.CategoryId;

            _dbContext.Products.Add(product);
            _dbContext.SaveChanges();
            
        }

        public class CreateProductModel
        {
            public string Name { get; set; }
            public decimal Price { get; set; }
            public string Description { get; set; }
            public int CategoryId { get; set; }
        }


    }
}