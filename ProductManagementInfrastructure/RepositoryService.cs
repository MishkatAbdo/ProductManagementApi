using Microsoft.Extensions.DependencyInjection;
using ProductManagementDomain.Repositories;
using ProductManagementInfrastructure.Repositories;

namespace ProductManagementInfrastructure;

public static class RepositoryService
{
    public static IServiceCollection AddRepositoryServices(this IServiceCollection services)
    {
        #region Repositories
        // Generic

        services.AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>));
        services.AddTransient<IProductRepository, ProductsRepository>();
        #endregion

        return services;
    }
}
