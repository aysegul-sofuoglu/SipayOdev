using WebApi.DBOperations;

namespace WebApi.ProductOperations.UpdateProduct{

    public class UpdateProductCommand{
        private readonly ProductsDbContext _dbContext;
        public int ProductId { get; set; }
        public UpdateProductModel Model { get; set; }
        public UpdateProductCommand(ProductsDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public void Handle()
        {
             var product = _dbContext.Products.SingleOrDefault(x=>x.Id==ProductId);

            if(product is null){
                throw new InvalidOperationException("Product not found");
            }

            product.Name = Model.Name != "string" ? Model.Name : product.Name;
            product.Price = Model.Price != default ? Model.Price : product.Price;
            product.Description = Model.Description != "string" ? Model.Description : product.Description;
            product.CategoryId = Model.CategoryId != default ? Model.CategoryId : product.CategoryId;

            _dbContext.SaveChanges();
        }

        public class UpdateProductModel
        {
            public string Name { get; set; }
            public decimal Price { get; set; }
            public string Description { get; set; }
            public int CategoryId { get; set; }
        }
    }

}