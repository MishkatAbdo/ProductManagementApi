using MediatR;
using ProductManagementApplication.Common;
using ProductManagementDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagementApplication.Products.Commands
{
    public class DeleteProductCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public DeleteProductCommand(int productId)
        {
            Id = productId;
        }
    }
}
