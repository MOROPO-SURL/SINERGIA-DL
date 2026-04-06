using Microsoft.EntityFrameworkCore;
using MOROPO.GEDET.CAM.Domain.Aggretates.ImageAggregate;
using MOROPO.GEDET.CAM.Domain.Aggretates.KeyVariableAggregate;
using MOROPO.GEDET.CAM.Domain.Aggretates.ObjectiveAggregate;
using MOROPO.GEDET.CAM.Domain.Aggretates.PermissionAggregate;
using MOROPO.GEDET.CAM.Domain.Aggretates.PermissionAggregate.Values;
using MOROPO.GEDET.CAM.Domain.Aggretates.RoleAggregate;
using MOROPO.GEDET.CAM.Domain.Aggretates.UserAggregate;
using MOROPO.GEDET.CAM.Domain.Bridges;
using MOROPO.GEDET.CAM.Infrastructure.Constants;
using MOROPO.GEDET.CAM.Infrastructure.Extensions;

namespace MOROPO.GEDET.CAM.Infrastructure.Persistence.EF;

public class DefaultDbContext : DbContext
{
    public DefaultDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Image> Images { get; set; }
    public DbSet<Permission> Permissions { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<RolePermissionBridge> RolePermissionBridges { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<UserRoleBridge> UserRoleBridges { get; set; }
    public DbSet<KeyVariable> KeyVariables { get; set; }
    public DbSet<Objective> Objectives { get; set; }
    public DbSet<ObjectiveKeyVariableBridge> ObjectiveKeyVariableBridges { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(GetType().Assembly);

        base.OnModelCreating(builder);
    }

    public bool LoadCoreSeeding()
    {
        var hasSeedingChanges = false;

        KeyValuePair<string, string[]>[] constants = 
        [
            new(PermissionFamilyConstants.USER_PERMISSIONS_FAMILY,
            [
                PermissionConstants.USER_LIST_PERMISSION,
                PermissionConstants.USER_VIEW_PERMISSION,
                PermissionConstants.USER_CREATE_PERMISSION,
                PermissionConstants.USER_UPDATE_PERMISSION,
                PermissionConstants.USER_REMOVE_PERMISSION,
                PermissionConstants.USER_ENABLE_PERMISSION,
                PermissionConstants.USER_DISABLE_PERMISSION
            ]),
            new(PermissionFamilyConstants.ROLE_PERMISSIONS_FAMILY,
            [
                PermissionConstants.ROLE_LIST_PERMISSION,
                PermissionConstants.ROLE_VIEW_PERMISSION,
                PermissionConstants.ROLE_CREATE_PERMISSION,
                PermissionConstants.ROLE_UPDATE_PERMISSION,
                PermissionConstants.ROLE_REMOVE_PERMISSION
            ]),
            new (PermissionFamilyConstants.PERSON_PERMISSIONS_FAMILY,
            [
                PermissionConstants.PERSON_LIST_PERMISSION,
                PermissionConstants.PERSON_VIEW_PERMISSION,
                PermissionConstants.PERSON_CREATE_PERMISSION,
                PermissionConstants.PERSON_UPDATE_PERMISSION,
                PermissionConstants.PERSON_REMOVE_PERMISSION,
                PermissionConstants.PERSON_ENABLE_PERMISSION,
                PermissionConstants.PERSON_DISABLE_PERMISSION,
                PermissionConstants.PERSON_ARCHIVE_PERMISSION,
                PermissionConstants.PERSON_UNARCHIVE_PERMISSION
            ])
        ];

        foreach (KeyValuePair<string, string[]> group in constants)
        {
            foreach (string item in group.Value)
            {
                PermissionId id = new PermissionId(item); 

                if (!Permissions.Any(entity => entity.Id == id))
                {
                    Permissions.Add(item.ToPermissionEntity(group.Key));

                    if (!hasSeedingChanges) hasSeedingChanges = true;
                }
            }
        }

        return hasSeedingChanges;
    }
}
