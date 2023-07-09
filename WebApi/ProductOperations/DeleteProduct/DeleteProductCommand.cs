using WebApi.DBOperations;

namespace WebApi.ProductOperations.DeleteProduct{
    public class DeleteProductCommand{
        private readonly ProductsDbContext _dbContext;
        public int ProductId { get; set; }

        public DeleteProductCommand(ProductsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            var product = _dbContext.Products.SingleOrDefault(x=>x.Id==ProductId);
            if(product is null){
                throw new InvalidOperationException("Product not found");
            }

            _dbContext.Products.Remove(product);
            _dbContext.SaveChanges();
        }
    }
}