using FluentValidation;

namespace WebApi.ProductOperations.CreateProduct{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(command => command.Model.CategoryId).NotEmpty().GreaterThan(0);
            RuleFor(command => command.Model.Price).NotEmpty().GreaterThan(0);
            RuleFor(command => command.Model.Name).NotEmpty();
            RuleFor(command => command.Model.Description).NotEmpty();
        }
    }

}