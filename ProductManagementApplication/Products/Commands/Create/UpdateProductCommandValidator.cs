using FluentValidation;
using ProductManagementDomain.Repositories;

namespace ProductManagementApplication.Products.Commands.Create;

public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
{
    //private readonly IProductRepository _productRepository;
    public UpdateProductCommandValidator(IProductRepository productRepository)
    {
        //  _productRepository = productRepository;
        // TODO: Check if ID is exists From DB.

        RuleFor(command => command.UpdateProductDto.Name)
            .NotEmpty().WithMessage("Product name is required.")
            .Length(2, 20).WithMessage("Product name must be between 2 and 20 characters.");

        RuleFor(command => command.UpdateProductDto.Price)
            .GreaterThan(0).WithMessage("Price must be greater than 0.");
    }
}
