using FluentValidation;
using ProductManagementApplication.Products.Commands;
using ProductManagementDomain.DTOs;
using ProductManagementDomain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagementApplication.Products.Validators
{
    public class UpdateProductCommandValidator : AbstractValidator<ProductDto>
    {
        private readonly IProductRepository _productService;

        public UpdateProductCommandValidator(IProductRepository productService)
        {
            _productService = productService;

            RuleFor(command => command.Id)
                .MustAsync(async (id, cancellation) => await ProductExists(id))
                .WithMessage("Product ID does not exist.");

            RuleFor(command => command.Price)
                .GreaterThan(0)
                .WithMessage("Price must be greater than 0.");

            RuleFor(command => command.Name)
                .NotEmpty()
                .WithMessage("Product name is required.")
                .Length(2, 20)
                .WithMessage("Product name must be between 2 and 20 characters.");
        }

        private async Task<bool> ProductExists(int id)
        {
            return await _productService.ExistsAsync(id);
        }
    }
}
