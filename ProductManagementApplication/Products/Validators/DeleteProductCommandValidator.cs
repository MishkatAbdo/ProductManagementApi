using FluentValidation;
using ProductManagementApplication.Products.Commands;
using ProductManagementDomain.Repositories;

namespace ProductManagementApplication.Products.Validators
{
    public class DeleteProductCommandValidator : AbstractValidator<DeleteProductCommand>
    {
        private readonly IProductRepository _productRepository;

        public DeleteProductCommandValidator(IProductRepository productRepository)
        {
            _productRepository = productRepository;

            RuleFor(command => command.Id)
            .MustAsync(ProductExists)
            .WithMessage("Product ID does not exist.");
        }

        private async Task<bool> ProductExists(int id, CancellationToken cancellationToken)
        {
            return await _productRepository.ExistsAsync(id);
        }
    }
}
