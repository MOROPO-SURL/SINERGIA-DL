using Microsoft.Extensions.DependencyInjection;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection UseCoreLayer(this IServiceCollection services)
    {
        services.AddMediatR(config => config.RegisterServicesFromAssembly(typeof(ServiceCollectionExtensions).Assembly));

        return services;
    }
}