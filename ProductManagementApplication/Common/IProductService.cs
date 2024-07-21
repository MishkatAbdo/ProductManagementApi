using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagementApplication.Common
{
    public interface IProductService
    {
        Task<bool> Exists(int id);
    }
    public class ProductService : IProductService
    {
        public Task<bool> Exists(int id)
        {
            return Task.FromResult(true);
        }
    }
}
