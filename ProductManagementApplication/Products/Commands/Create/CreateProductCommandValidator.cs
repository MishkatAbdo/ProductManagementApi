using FluentValidation;
using ProductManagementDomain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagementApplication.Products.Commands.Create
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(command => command.Name)
                .NotEmpty().WithMessage("Product name is required.")
                .Length(2, 20).WithMessage("Product name must be between 2 and 20 characters.");

            RuleFor(command => command.Price)
                .GreaterThan(0).WithMessage("Price must be greater than 0.");
        }

    }
}
