using Microsoft.EntityFrameworkCore;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.ClasificationAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.ImageAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.InterestAreaAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.KeyVariableAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.MacroprogramAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.ObjectiveAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.OrganizationAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.OrganizationKindAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.PermissionAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.PermissionAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.PersonAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.PublicPolicyAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.RoleAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicAxesAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicLineAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicProgramAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicProjectAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TerritorialBarrierAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TerritoryPotentialAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.UnitMeasurementAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.UserAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Bridges;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Constants;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Extensions;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Persistence.EF;

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
    public DbSet<Clasification> Clasifications { get; set; }
    public DbSet<InterestArea> InterestAreas { get; set; }
    public DbSet<Macroprogram> Macroprograms { get; set; }
    public DbSet<OrganizationKind> OrganizationKinds { get; set; }
    public DbSet<Organization> Organizations { get; set; }
    public DbSet<OrganizationClasificationBridge> OrganizationClasificationBridges { get; set; }
    public DbSet<Person> People { get; set; }
    public DbSet<PersonOrganizationBrigde> PersonOrganizationBrigdes { get; set; }
    public DbSet<PublicPolicy> PublicPolicies { get; set; }
    public DbSet<TerritorialBarrier> TerritorialBarriers { get; set; }
    public DbSet<TerritoryPotential> TerritoryPotentials { get; set; }
    public DbSet<UnitMeasurement> UnitMeasurements { get; set; }
    public DbSet<StrategicAxe> StrategicAxes { get; set; }
    public DbSet<StrategicLine> StrategicLines { get; set; }
    public DbSet<StrategicProgram> StrategicPrograms { get; set; }
    public DbSet<StrategicProject> StrategicProjects { get; set; }
    public DbSet<StrategicProgramOrganizationBridge> StrategicProgramOrganizationBridges { get; set; }

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
            ]),
            new (PermissionFamilyConstants.UNITMEASUREMENT_PERMISSIONS_FAMILY,
            [
                PermissionConstants.UNITMEASUREMENT_LIST_PERMISSION,
                PermissionConstants.UNITMEASUREMENT_VIEW_PERMISSION,
                PermissionConstants.UNITMEASUREMENT_CREATE_PERMISSION,
                PermissionConstants.UNITMEASUREMENT_UPDATE_PERMISSION,
                PermissionConstants.UNITMEASUREMENT_REMOVE_PERMISSION,
                PermissionConstants.UNITMEASUREMENT_ARCHIVE_PERMISSION,
                PermissionConstants.UNITMEASUREMENT_UNARCHIVE_PERMISSION,
                PermissionConstants.UNITMEASUREMENT_ENABLE_PERMISSION,
                PermissionConstants.UNITMEASUREMENT_DISABLE_PERMISSION
            ]),
            new (PermissionFamilyConstants.INTERESTAREA_PERMISSIONS_FAMILY,
            [
                PermissionConstants.INTERESTAREA_LIST_PERMISSION,
                PermissionConstants.INTERESTAREA_VIEW_PERMISSION,
                PermissionConstants.INTERESTAREA_CREATE_PERMISSION,
                PermissionConstants.INTERESTAREA_UPDATE_PERMISSION,
                PermissionConstants.INTERESTAREA_REMOVE_PERMISSION,
                PermissionConstants.INTERESTAREA_ARCHIVE_PERMISSION,
                PermissionConstants.INTERESTAREA_UNARCHIVE_PERMISSION,
                PermissionConstants.INTERESTAREA_ENABLE_PERMISSION,
                PermissionConstants.INTERESTAREA_DISABLE_PERMISSION
            ]),
            new (PermissionFamilyConstants.MACROPROGRAM_PERMISSIONS_FAMILY,
            [
                PermissionConstants.MACROPROGRAM_LIST_PERMISSION,
                PermissionConstants.MACROPROGRAM_VIEW_PERMISSION,
                PermissionConstants.MACROPROGRAM_CREATE_PERMISSION,
                PermissionConstants.MACROPROGRAM_UPDATE_PERMISSION,
                PermissionConstants.MACROPROGRAM_REMOVE_PERMISSION,
                PermissionConstants.MACROPROGRAM_ARCHIVE_PERMISSION,
                PermissionConstants.MACROPROGRAM_UNARCHIVE_PERMISSION
            ]),
            new (PermissionFamilyConstants.PUBLICPOLICY_PERMISSIONS_FAMILY,
            [
                PermissionConstants.PUBLICPOLICY_LIST_PERMISSION,
                PermissionConstants.PUBLICPOLICY_VIEW_PERMISSION,
                PermissionConstants.PUBLICPOLICY_CREATE_PERMISSION,
                PermissionConstants.PUBLICPOLICY_UPDATE_PERMISSION,
                PermissionConstants.PUBLICPOLICY_REMOVE_PERMISSION,
                PermissionConstants.PUBLICPOLICY_ARCHIVE_PERMISSION,
                PermissionConstants.PUBLICPOLICY_UNARCHIVE_PERMISSION
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
