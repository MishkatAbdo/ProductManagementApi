using MediatR;
using ProductManagementDomain.Repositories;

namespace ProductManagementApplication.Products.Commands
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand,bool>
    {
        private readonly IProductRepository _productRepository;

        public DeleteProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _productRepository.DeleteAsync(request.Id);
                return true;

            }
            catch (Exception ex)
            {

                throw ex;
            }

            
        }

    }
}
