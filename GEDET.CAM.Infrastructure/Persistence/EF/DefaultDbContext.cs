using Microsoft.EntityFrameworkCore;
using MOROPO.GEDET.CAM.Domain.Aggretates.KeyVariableAggregate;
using MOROPO.GEDET.CAM.Domain.Aggretates.ObjectiveAggregate;
using MOROPO.GEDET.CAM.Domain.Aggretates.PermissionAggregate;
using MOROPO.GEDET.CAM.Domain.Aggretates.RoleAggregate;
using MOROPO.GEDET.CAM.Domain.Bridges;

namespace MOROPO.GEDET.CAM.Infrastructure.Persistence.EF;

public class DefaultDbContext : DbContext
{
    public DefaultDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Permission> Permissions { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<RolePermissionBridge> RolePermissionBridges { get; set; }
    public DbSet<KeyVariable> KeyVariables { get; set; }
    public DbSet<Objective> Objectives { get; set; }
    public DbSet<ObjectiveKeyVariableBridge> ObjectiveKeyVariableBridges { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(GetType().Assembly);

        base.OnModelCreating(builder);
    }
}
