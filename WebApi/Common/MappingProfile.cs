using AutoMapper;
using WebApi.ProductOperations.GetProducts;
using static WebApi.ProductOperations.CreateProduct.CreateProductCommand;
using static WebApi.ProductOperations.GetProductDetail.GetProductDetailQuery;

namespace WebApi.Common{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateProductModel, Product>();
            CreateMap<Product, ProductDetailViewModel>().ForMember(dest => dest.Category, opt => opt.MapFrom(src => ((CategoryEnum)src.CategoryId).ToString()));
            CreateMap<Product, ProductViewModel>().ForMember(dest => dest.Category, opt => opt.MapFrom(src => ((CategoryEnum)src.CategoryId).ToString()));
        }
    }
}