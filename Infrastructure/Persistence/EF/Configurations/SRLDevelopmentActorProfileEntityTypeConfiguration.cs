using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.DevelopmentActorProfileAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.DevelopmentActorProfileAggregate.Bridges;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.DevelopmentActorProfileAggregate.Entities;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.DevelopmentActorProfileAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Persistence.EF.Configurations;

internal sealed class SRLDevelopmentActorProfileEntityTypeConfiguration : IEntityTypeConfiguration<SRLDevelopmentActorProfile>
{
    private const string ROOT_TABLE_NAME = "srldevelopmentactorprofiles";
    private const string PRODUCTION_ACTIVITY_TABLE_NAME = "srldevelopmentactorprofile_productionactivities";
    private const string COMMERCIAL_ACTIVITY_TABLE_NAME = "srldevelopmentactorprofile_commercialactivities";
    private const string SERVICING_ACTIVITY_TABLE_NAME = "srldevelopmentactorprofile_servicingactivities";
    private const string ECONOMICACTIVITY_BRIDGE_TABLE_NAME = "srldevelopmentactorprofile_economicactivity_bridges";
    private const string ORGANIZATION_BRIDGE_TABLE_NAME = "srldevelopmentactorprofile_organization_bridges";
    private const string PERSON_BRIDGE_TABLE_NAME = "srldevelopmentactorprofile_person_bridges";

    public void Configure(EntityTypeBuilder<SRLDevelopmentActorProfile> builder)
    {
        builder.ToTable(ROOT_TABLE_NAME);

        builder.Property(entity => entity.Id)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => new DevelopmentActorProfileId(value));

        builder.Property(entity => entity.OwnerId)
            .HasConversion(id => id.Value, value => new Domain.Aggretates.OrganizationAggregate.Values.OrganizationId(value));

        builder.Property(entity => entity.MainEconomicActivityId)
            .HasConversion(id => id.Value, value => new Domain.Aggretates.EconomicActivityAggregate.Values.EconomicActivityId(value));

        builder.Property(entity => entity.About)
            .HasMaxLength(2048);

        builder.HasKey(entity => entity.Id);

        builder.HasOne(entity => entity.Owner).WithMany().HasForeignKey(entity => entity.OwnerId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(entity => entity.MainEconomicActivity).WithMany().HasForeignKey(entity => entity.MainEconomicActivityId).OnDelete(DeleteBehavior.Restrict);

        builder.OwnsMany(entity => entity.ProductionActivities, Configure)
            .Navigation(entity => entity.ProductionActivities)
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasField("productionActivities");

        builder.OwnsMany(entity => entity.CommercialActivities, Configure)
            .Navigation(entity => entity.CommercialActivities)
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasField("commercialActivities");

        builder.OwnsMany(entity => entity.ServicingActivities, Configure)
            .Navigation(entity => entity.ServicingActivities)
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasField("servicingActivities");

        builder.OwnsMany(entity => entity.SecoundaryEconomicActivityBridges, Configure)
            .Navigation(entity => entity.SecoundaryEconomicActivityBridges)
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasField("secoundaryEconomicActivityBridges");

        builder.OwnsMany(entity => entity.OrganizationBridges, Configure)
            .Navigation(entity => entity.OrganizationBridges)
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasField("organizationBridges");

        builder.OwnsMany(entity => entity.PersonBridges, Configure)
            .Navigation(entity => entity.PersonBridges)
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasField("personBridges");
    }

    private void Configure(OwnedNavigationBuilder<SRLDevelopmentActorProfile, DevelopmentActorProfileProductionActivity> builder)
    {
        builder.ToTable(PRODUCTION_ACTIVITY_TABLE_NAME);

        builder.Property(entity => entity.Id)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => new DevelopmentActorProfileProductionActivityId(value));

        builder.Property(entity => entity.DevelopmentActorProfileId)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => new DevelopmentActorProfileId(value));

        builder.Property(entity => entity.ProductId)
            .HasConversion(id => id.Value, value => new Domain.Aggretates.ProductAggregate.Values.ProductId(value));

        builder.Property(entity => entity.Description)
            .HasMaxLength(4096);

        builder.HasKey(entity => new { entity.Id, entity.DevelopmentActorProfileId });

        builder.WithOwner().HasForeignKey(entity => entity.DevelopmentActorProfileId);

        builder.HasOne(entity => entity.Product).WithMany().HasForeignKey(entity => entity.ProductId).OnDelete(DeleteBehavior.Restrict);
    }

    private void Configure(OwnedNavigationBuilder<SRLDevelopmentActorProfile, DevelopmentActorProfileCommercialActivity> builder)
    {
        builder.ToTable(COMMERCIAL_ACTIVITY_TABLE_NAME);

        builder.Property(entity => entity.Id)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => new DevelopmentActorProfileCommercialActivityId(value));

        builder.Property(entity => entity.DevelopmentActorProfileId)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => new DevelopmentActorProfileId(value));

        builder.Property(entity => entity.ProductId)
            .HasConversion(id => id.Value, value => new Domain.Aggretates.ProductAggregate.Values.ProductId(value));

        builder.Property(entity => entity.Description)
            .HasMaxLength(4096);

        builder.HasKey(entity => new { entity.Id, entity.DevelopmentActorProfileId });

        builder.WithOwner().HasForeignKey(entity => entity.DevelopmentActorProfileId);

        builder.HasOne(entity => entity.Product).WithMany().HasForeignKey(entity => entity.ProductId).OnDelete(DeleteBehavior.Restrict);
    }

    private void Configure(OwnedNavigationBuilder<SRLDevelopmentActorProfile, DevelopmentActorProfileServicingActivity> builder)
    {
        builder.ToTable(SERVICING_ACTIVITY_TABLE_NAME);

        builder.Property(entity => entity.Id)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => new DevelopmentActorProfileServicingActivityId(value));

        builder.Property(entity => entity.DevelopmentActorProfileId)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => new DevelopmentActorProfileId(value));

        builder.Property(entity => entity.ServiceId)
            .HasConversion(id => id.Value, value => new Domain.Aggretates.ServiceAggregate.Values.ServiceId(value));

        builder.Property(entity => entity.Description)
            .HasMaxLength(4096);

        builder.HasKey(entity => new { entity.Id, entity.DevelopmentActorProfileId });

        builder.WithOwner().HasForeignKey(entity => entity.DevelopmentActorProfileId);

        builder.HasOne(entity => entity.Service).WithMany().HasForeignKey(entity => entity.ServiceId).OnDelete(DeleteBehavior.Restrict);
    }

    private void Configure(OwnedNavigationBuilder<SRLDevelopmentActorProfile, DevelopmentActorProfileEconomicActivityBridge> builder)
    {
        builder.ToTable(ECONOMICACTIVITY_BRIDGE_TABLE_NAME);

        builder.Property(bridge => bridge.MainId)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => new DevelopmentActorProfileId(value));

        builder.Property(bridge => bridge.LinkedId)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => new Domain.Aggretates.EconomicActivityAggregate.Values.EconomicActivityId(value));

        builder.HasKey(bridge => new { bridge.MainId, bridge.LinkedId });

        builder.WithOwner().HasForeignKey(bridge => bridge.MainId);

        builder.HasOne(bridge => bridge.Linked).WithMany().HasForeignKey(bridge => bridge.LinkedId).OnDelete(DeleteBehavior.Restrict);
    }

    private void Configure(OwnedNavigationBuilder<SRLDevelopmentActorProfile, SRLDevelopmentActorProfileOrganizationBridge> builder)
    {
        builder.ToTable(ORGANIZATION_BRIDGE_TABLE_NAME);

        builder.Property(bridge => bridge.MainId)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => new DevelopmentActorProfileId(value));

        builder.Property(bridge => bridge.LinkedId)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => new Domain.Aggretates.OrganizationAggregate.Values.OrganizationId(value));

        builder.HasKey(bridge => new { bridge.MainId, bridge.LinkedId });

        builder.WithOwner().HasForeignKey(bridge => bridge.MainId);

        builder.HasOne(bridge => bridge.Linked).WithMany().HasForeignKey(bridge => bridge.LinkedId).OnDelete(DeleteBehavior.Restrict);
    }

    private void Configure(OwnedNavigationBuilder<SRLDevelopmentActorProfile, SRLDevelopmentActorProfilePersonBridge> builder)
    {
        builder.ToTable(PERSON_BRIDGE_TABLE_NAME);

        builder.Property(bridge => bridge.MainId)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => new DevelopmentActorProfileId(value));

        builder.Property(bridge => bridge.LinkedId)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => new Domain.Aggretates.PersonAggregate.Values.PersonId(value));

        builder.HasKey(bridge => new { bridge.MainId, bridge.LinkedId });

        builder.WithOwner().HasForeignKey(bridge => bridge.MainId);

        builder.HasOne(entity => entity.Linked).WithMany().HasForeignKey(bridge => bridge.LinkedId).OnDelete(DeleteBehavior.Restrict);
    }
}
