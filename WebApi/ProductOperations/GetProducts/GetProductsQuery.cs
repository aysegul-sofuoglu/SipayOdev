using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApi.Common;
using WebApi.DBOperations;

namespace WebApi.ProductOperations.GetProducts{

    public class GetProductsQuery
    {
        private readonly ProductsDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetProductsQuery(ProductsDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<ProductViewModel> Handle()
        {
            
            var productList = _dbContext.Products.OrderBy(x=>x.Id).ToList<Product>();
            List<ProductViewModel> vm = _mapper.Map<List<ProductViewModel>>(productList);
            //new List<ProductViewModel>();
            // foreach(var product in productList)
            // {
            //     vm.Add(new ProductViewModel(){
            //         Name= product.Name,
            //         Price=product.Price,
            //         Description=product.Description,
            //         Category=((CategoryEnum)product.CategoryId).ToString()
            //     });
            // }
            return vm;
        }
    }

    public class ProductViewModel{
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
    }
}