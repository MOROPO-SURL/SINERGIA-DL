using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MOROPO.GEDET.CAM.Core.Roles.Ports.Repository;

namespace MOROPO.GEDET.CAM.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection UseInfrastructure(this IServiceCollection services, IConfigurationManager configuration)
    {
        services.AddDbContext<Persistence.EF.DefaultDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped<IRoleQueryRepositoryPort, Adapters.Repository.RoleRepository>();

        return services;
    }
}
