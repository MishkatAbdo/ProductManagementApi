using FluentValidation;
using ProductManagementApplication.Common;
using ProductManagementDomain.Repositories;

namespace ProductManagementApplication.Products.Validators
{
    public abstract class BaseValidator<T> : AbstractValidator<T> where T : IHasId
    {
        protected readonly IProductRepository _productRepository;

        protected BaseValidator(IProductRepository productRepository)
        {
            _productRepository = productRepository;

            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("ID is required.")
                .MustAsync(Exists).WithMessage("Entity with the given ID does not exist.");
        }

        private async Task<bool> Exists(int id, CancellationToken cancellationToken)
        {
            return await _productRepository.ExistsAsync(id);
        }
    }
}
