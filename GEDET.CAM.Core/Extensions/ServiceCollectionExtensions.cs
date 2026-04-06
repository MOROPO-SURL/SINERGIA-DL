using Microsoft.Extensions.DependencyInjection;

namespace MOROPO.GEDET.CAM.Core.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection UseCoreLayer(this IServiceCollection services)
    {
        services.AddMediatR(config => config.RegisterServicesFromAssembly(typeof(ServiceCollectionExtensions).Assembly));

        return services;
    }
}