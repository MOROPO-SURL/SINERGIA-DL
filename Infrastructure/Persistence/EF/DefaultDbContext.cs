using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.PermissionAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.PermissionAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Constants;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Extensions;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Persistence.EF;

public class DefaultDbContext : DbContext
{
    private readonly IEnumerable<ISaveChangesInterceptor> saveChangesInterceptors;

    public DefaultDbContext(DbContextOptions options, IEnumerable<ISaveChangesInterceptor> saveChangesInterceptors) : base(options)
    {
        this.saveChangesInterceptors = saveChangesInterceptors;
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(GetType().Assembly);

        base.OnModelCreating(builder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors(saveChangesInterceptors);

        base.OnConfiguring(optionsBuilder);
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
            new(PermissionFamilyConstants.APIKEY_PERMISSIONS_FAMILY,
            [
                PermissionConstants.APIKEY_LIST_PERMISSION,
                PermissionConstants.APIKEY_VIEW_PERMISSION,
                PermissionConstants.APIKEY_CREATE_PERMISSION,
                PermissionConstants.APIKEY_UPDATE_PERMISSION,
                PermissionConstants.APIKEY_REMOVE_PERMISSION
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
            ]),
            new (PermissionFamilyConstants.ORGANIZATIONKIND_PERMISSIONS_FAMILY,
            [
                PermissionConstants.ORGANIZATIONKIND_LIST_PERMISSION,
                PermissionConstants.ORGANIZATIONKIND_VIEW_PERMISSION,
                PermissionConstants.ORGANIZATIONKIND_CREATE_PERMISSION,
                PermissionConstants.ORGANIZATIONKIND_UPDATE_PERMISSION,
                PermissionConstants.ORGANIZATIONKIND_REMOVE_PERMISSION,
                PermissionConstants.ORGANIZATIONKIND_ARCHIVE_PERMISSION,
                PermissionConstants.ORGANIZATIONKIND_UNARCHIVE_PERMISSION,
                PermissionConstants.ORGANIZATIONKIND_ENABLE_PERMISSION,
                PermissionConstants.ORGANIZATIONKIND_DISABLE_PERMISSION
            ]),
            new (PermissionFamilyConstants.TERRITORIALBARRIER_PERMISSIONS_FAMILY,
            [
                PermissionConstants.TERRITORIALBARRIER_LIST_PERMISSION,
                PermissionConstants.TERRITORIALBARRIER_VIEW_PERMISSION,
                PermissionConstants.TERRITORIALBARRIER_CREATE_PERMISSION,
                PermissionConstants.TERRITORIALBARRIER_UPDATE_PERMISSION,
                PermissionConstants.TERRITORIALBARRIER_REMOVE_PERMISSION,
                PermissionConstants.TERRITORIALBARRIER_ARCHIVE_PERMISSION,
                PermissionConstants.TERRITORIALBARRIER_UNARCHIVE_PERMISSION
            ]),
            new (PermissionFamilyConstants.TERRITORYPOTENTIAL_PERMISSIONS_FAMILY,
            [
                PermissionConstants.TERRITORYPOTENTIAL_LIST_PERMISSION,
                PermissionConstants.TERRITORYPOTENTIAL_VIEW_PERMISSION,
                PermissionConstants.TERRITORYPOTENTIAL_CREATE_PERMISSION,
                PermissionConstants.TERRITORYPOTENTIAL_UPDATE_PERMISSION,
                PermissionConstants.TERRITORYPOTENTIAL_REMOVE_PERMISSION,
                PermissionConstants.TERRITORYPOTENTIAL_ARCHIVE_PERMISSION,
                PermissionConstants.TERRITORYPOTENTIAL_UNARCHIVE_PERMISSION
            ]),
            new (PermissionFamilyConstants.CLASIFICATION_PERMISSIONS_FAMILY,
            [
                PermissionConstants.CLASIFICATION_LIST_PERMISSION,
                PermissionConstants.CLASIFICATION_VIEW_PERMISSION,
                PermissionConstants.CLASIFICATION_CREATE_PERMISSION,
                PermissionConstants.CLASIFICATION_UPDATE_PERMISSION,
                PermissionConstants.CLASIFICATION_REMOVE_PERMISSION,
                PermissionConstants.CLASIFICATION_ARCHIVE_PERMISSION,
                PermissionConstants.CLASIFICATION_UNARCHIVE_PERMISSION,
                PermissionConstants.CLASIFICATION_ENABLE_PERMISSION,
                PermissionConstants.CLASIFICATION_DISABLE_PERMISSION
            ]),
            new (PermissionFamilyConstants.KEYVARIABLE_PERMISSIONS_FAMILY,
            [
                PermissionConstants.KEYVARIABLE_LIST_PERMISSION,
                PermissionConstants.KEYVARIABLE_VIEW_PERMISSION,
                PermissionConstants.KEYVARIABLE_CREATE_PERMISSION,
                PermissionConstants.KEYVARIABLE_UPDATE_PERMISSION,
                PermissionConstants.KEYVARIABLE_REMOVE_PERMISSION,
                PermissionConstants.KEYVARIABLE_ARCHIVE_PERMISSION,
                PermissionConstants.KEYVARIABLE_UNARCHIVE_PERMISSION
            ]),
            new (PermissionFamilyConstants.ORGANIZATION_PERMISSIONS_FAMILY,
            [
                PermissionConstants.ORGANIZATION_VIEW_PERMISSION,
                PermissionConstants.ORGANIZATION_CREATE_PERMISSION,
                PermissionConstants.ORGANIZATION_UPDATE_PERMISSION,
                PermissionConstants.ORGANIZATION_REMOVE_PERMISSION,
                PermissionConstants.ORGANIZATION_ARCHIVE_PERMISSION,
                PermissionConstants.ORGANIZATION_UNARCHIVE_PERMISSION,
                PermissionConstants.ORGANIZATION_ENABLE_PERMISSION,
                PermissionConstants.ORGANIZATION_DISABLE_PERMISSION
            ]),
            new (PermissionFamilyConstants.FEATUREKIND_PERMISSIONS_FAMILY,
            [
                PermissionConstants.FEATUREKIND_LIST_PERMISSION,
                PermissionConstants.FEATUREKIND_VIEW_PERMISSION,
                PermissionConstants.FEATUREKIND_CREATE_PERMISSION,
                PermissionConstants.FEATUREKIND_UPDATE_PERMISSION,
                PermissionConstants.FEATUREKIND_REMOVE_PERMISSION,
                PermissionConstants.FEATUREKIND_ENABLE_PERMISSION,
                PermissionConstants.FEATUREKIND_DISABLE_PERMISSION
            ]),
            new (PermissionFamilyConstants.ECONOMICACTIVITY_PERMISSIONS_FAMILY,
            [
                PermissionConstants.ECONOMICACTIVITY_LIST_PERMISSION,
                PermissionConstants.ECONOMICACTIVITY_VIEW_PERMISSION,
                PermissionConstants.ECONOMICACTIVITY_CREATE_PERMISSION,
                PermissionConstants.ECONOMICACTIVITY_UPDATE_PERMISSION,
                PermissionConstants.ECONOMICACTIVITY_REMOVE_PERMISSION,
                PermissionConstants.ECONOMICACTIVITY_ENABLE_PERMISSION,
                PermissionConstants.ECONOMICACTIVITY_DISABLE_PERMISSION
            ])
        ];

        foreach (KeyValuePair<string, string[]> group in constants)
        {
            foreach (string item in group.Value)
            {
                PermissionId id = new(item);

                DbSet<Permission> permissionSet = Set<Permission>();

                if (!permissionSet.Any(entity => entity.Id == id))
                {
                    permissionSet.Add(item.ToPermissionEntity(group.Key));

                    if (!hasSeedingChanges) hasSeedingChanges = true;
                }
            }
        }

        return hasSeedingChanges;
    }
}
