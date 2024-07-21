using MediatR;
using ProductManagementDomain.Repositories;

namespace ProductManagementApplication.Products.Queries;

public record IsProductExistsQuery(int Id) : IRequest<bool>;

internal sealed class IsProductExistsQueryHandler : IRequestHandler<IsProductExistsQuery, bool>
{
    private readonly IProductRepository _productRepository;

    public IsProductExistsQueryHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<bool> Handle(IsProductExistsQuery request, CancellationToken cancellationToken)
    {
        return await _productRepository.ExistsAsync(request.Id);

    }
}
