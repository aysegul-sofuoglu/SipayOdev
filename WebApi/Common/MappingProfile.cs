using AutoMapper;
using WebApi.Entities;
using WebApi.ProductOperations.GetProducts;
using static WebApi.ProductOperations.CreateProduct.CreateProductCommand;
using static WebApi.ProductOperations.GetProductDetail.GetProductDetailQuery;
using static WebApi.UserOperations.CreateUser.CreateUserCommand;

namespace WebApi.Common{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateProductModel, Product>();
            CreateMap<Product, ProductDetailViewModel>().ForMember(dest => dest.Category, opt => opt.MapFrom(src => ((CategoryEnum)src.CategoryId).ToString()));
            CreateMap<Product, ProductViewModel>().ForMember(dest => dest.Category, opt => opt.MapFrom(src => ((CategoryEnum)src.CategoryId).ToString()));
            CreateMap<CreateUserModel, User>();
        }
    }
}