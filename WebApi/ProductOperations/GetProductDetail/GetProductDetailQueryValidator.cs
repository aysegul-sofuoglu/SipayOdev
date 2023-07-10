using FluentValidation;

namespace WebApi.ProductOperations.GetProductDetail{
    public class GetProductDetailQueryValidator : AbstractValidator<GetProductDetailQuery>
    {
        public GetProductDetailQueryValidator()
        {
            RuleFor(query => query.ProductId).GreaterThan(0);
        }
    }
}