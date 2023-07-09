using Microsoft.AspNetCore.Mvc;
using WebApi.Common;
using WebApi.DBOperations;
using AutoMapper;

namespace WebApi.ProductOperations.GetProductDetail{

    public class GetProductDetailQuery{

        private readonly ProductsDbContext _dbContext;
        private readonly IMapper _mapper;
        public int ProductId{ get; set; }
        public GetProductDetailQuery(ProductsDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public ProductDetailViewModel Handle()
        {
            var product = _dbContext.Products.Where(product => product.Id == ProductId).SingleOrDefault();
            if(product is null){
                throw new InvalidOperationException("Product not found.");
            }
            ProductDetailViewModel vm = _mapper.Map<ProductDetailViewModel>(product); 
            //new ProductDetailViewModel();
            // vm.Name = product.Name;
            // vm.Price = product.Price;
            // vm.Description = product.Description;
            // vm.Category = ((CategoryEnum)product.CategoryId).ToString();
            
            return vm;
        }

        public class ProductDetailViewModel
        {
            public string Name { get; set; }
            public decimal Price { get; set; }
            public string Description { get; set; }
            public string Category { get; set; }
        }
    }
}