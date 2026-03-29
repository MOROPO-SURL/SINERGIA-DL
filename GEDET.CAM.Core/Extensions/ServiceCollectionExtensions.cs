using Mapster;
using Microsoft.Extensions.DependencyInjection;
using MOROPO.GEDET.CAM.Core.UseCases.Roles.DTOs.Mapping;

namespace MOROPO.GEDET.CAM.Core.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection UseCoreLayer(this IServiceCollection services)
    {
        services.AddMediatR(config => config.RegisterServicesFromAssembly(typeof(ServiceCollectionExtensions).Assembly));

        TypeAdapterConfig.GlobalSettings.Apply(
            new RoleEssentialDtoMapConfig()
        );

        return services;
    }
}