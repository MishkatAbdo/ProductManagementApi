using MediatR;
using ProductManagementDomain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagementApplication.Products.Queries
{
    public class GetAllProductsQuery : IRequest<List<ProductDto>>
    {
    }
}
