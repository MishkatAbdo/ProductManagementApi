using ProductManagementDomain.Common;

namespace ProductManagementDomain.DTOs;
public class ProductDto : IHasId
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
}
public class UpdateProductDto 
{
    public string Name { get; set; }
    public double Price { get; set; }
}
