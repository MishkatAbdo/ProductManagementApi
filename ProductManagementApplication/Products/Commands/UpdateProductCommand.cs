using MediatR;
using ProductManagementDomain.DTOs;

namespace ProductManagementApplication.Products.Commands
{
    public class UpdateProductCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public UpdateProductDto UpdateProductDto { get; set; }

        public UpdateProductCommand(UpdateProductDto productDto)
        {
            UpdateProductDto = productDto;
        }
    }
}
