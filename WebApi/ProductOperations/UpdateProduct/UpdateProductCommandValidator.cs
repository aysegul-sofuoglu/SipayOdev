using FluentValidation;

namespace WebApi.ProductOperations.UpdateProduct{
    public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>{
        public UpdateProductCommandValidator()
        {
            RuleFor(command => command.Model.CategoryId).NotEmpty().GreaterThan(0);
            RuleFor(command => command.Model.Price).NotEmpty().GreaterThan(0);
            RuleFor(command => command.Model.Name).NotEmpty();
            RuleFor(command => command.Model.Description).NotEmpty();
        }
    }
}