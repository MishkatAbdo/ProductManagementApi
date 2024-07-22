using FluentValidation;
using MediatR;
using ProductManagementDomain.DTOs;
using ProductManagementDomain.Entities;
using ProductManagementDomain.Repositories;

namespace ProductManagementApplication.Products.Commands
{
    /// <summary>
    /// This Is Implemention of : 
    /// </summary>
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, bool>
    {
        private readonly IProductRepository _productRepository;

        public UpdateProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {

            try
            {

                var product = new Product
                {
                    Id = request.Id,
                    Name = request.UpdateProductDto.Name,
                    Price = request.UpdateProductDto.Price

                };

                // Proceed with updating the product in the repository
                var result = await _productRepository.UpdateAsync(product);

                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
