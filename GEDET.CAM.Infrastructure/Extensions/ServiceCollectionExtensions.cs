using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MOROPO.GEDET.CAM.Core.Extensions;
using MOROPO.GEDET.CAM.Core.UseCases.Roles.Ports.Repository;
using MOROPO.GEDET.CAM.Infrastructure.Adapters.Repository.Roles;

namespace MOROPO.GEDET.CAM.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection UseInfrastructureLayer(this IServiceCollection services, IConfigurationManager configuration)
    {
        services.UseCoreLayer();

        services.AddDbContext<Persistence.EF.DefaultDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped<IRoleQueryRepositoryPort, RoleQueryRepositoryAdapter>();
        services.AddScoped<IRoleCommandRepositoryPort, RoleCommandRepositoryAdapter>();

        return services;
    }
}