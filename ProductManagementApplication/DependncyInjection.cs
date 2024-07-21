using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using FluentValidation;
using ProductManagementApplication.Products.Commands.Create;

namespace ProductManagementApplication;

public static class DependncyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {

        var assembly = Assembly.GetExecutingAssembly();
        // MediatR
        services.AddMediatR(assembly);
        services.AddValidatorsFromAssembly(assembly);
        //services.AddValidatorsFromAssemblyContaining<CreateProductCommandValidator>();
        return services;
    }
}
