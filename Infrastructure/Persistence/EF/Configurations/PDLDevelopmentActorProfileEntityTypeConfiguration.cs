using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.DevelopmentActorProfileAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.DevelopmentActorProfileAggregate.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.DevelopmentActorProfileAggregate.Bridges;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.DevelopmentActorProfileAggregate.Entities;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.DevelopmentActorProfileAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Persistence.EF.Configurations
{
    internal sealed class PDLDevelopmentActorProfileEntityTypeConfiguration : IEntityTypeConfiguration<AbstractPDLDevelopmentActorProfile>
    {
        private const string ROOT_TABLE_NAME = "pdldevelopmentactorprofiles";
        private const string PRODUCTION_ACTIVITY_TABLE_NAME = "pdldevelopmentactorprofile_productionactivities";
        private const string COMMERCIAL_ACTIVITY_TABLE_NAME = "pdldevelopmentactorprofile_commercialactivities";
        private const string SERVICING_ACTIVITY_TABLE_NAME = "pdldevelopmentactorprofile_servicingactivities";
        private const string LOCATION_BRIDGE_TABLE_NAME = "pdldevelopmentactorprofile_location_bridges";
        private const string ECONOMICACTIVITY_BRIDGE_TABLE_NAME = "pdldevelopmentactorprofile_economicactivity_bridges";

        public void Configure(EntityTypeBuilder<AbstractPDLDevelopmentActorProfile> builder)
        {
            builder.ToTable(ROOT_TABLE_NAME); builder.Property(entity => entity.Id)
                .ValueGeneratedNever()
                .HasConversion(id => id.Value, value => new DevelopmentActorProfileId(value));

            builder.Property(entity => entity.OwnerId)
                .HasConversion(id => id.Value, value => new Domain.Aggretates.OrganizationAggregate.Values.OrganizationId(value));

            builder.Property(entity => entity.FiscalIdentificationCode)
                .IsRequired()
                .HasMaxLength(120);

            builder.Property(entity => entity.ModalityId)
                .HasConversion(id => id.Value, value => new Domain.Aggretates.PDLModalityAggregate.Values.PDLModalityId(value));

            builder.Property(entity => entity.MainEconomicActivityId)
                .HasConversion(id => id.Value, value => new Domain.Aggretates.EconomicActivityAggregate.Values.EconomicActivityId(value));

            builder.Property(entity => entity.MainLocationId)
                .HasConversion(id => id.Value, value => new Domain.Aggretates.LocationAggregate.Values.LocationId(value));

            builder.Property(entity => entity.About)
                .HasMaxLength(2048);

            builder.HasKey(entity => entity.Id);

            builder.HasOne(entity => entity.Owner).WithMany().HasForeignKey(entity => entity.OwnerId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(entity => entity.Modality).WithMany().HasForeignKey(entity => entity.ModalityId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(entity => entity.MainEconomicActivity).WithMany().HasForeignKey(entity => entity.MainEconomicActivityId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(entity => entity.MainLocation).WithMany().HasForeignKey(entity => entity.MainLocationId).OnDelete(DeleteBehavior.Restrict);

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

            builder.OwnsMany(entity => entity.LocationBridges, Configure)
                .Navigation(entity => entity.LocationBridges)
                    .UsePropertyAccessMode(PropertyAccessMode.Field)
                    .HasField("locationBridges");

            builder.OwnsMany(entity => entity.SecoundaryEconomicActivityBridges, Configure)
                .Navigation(entity => entity.SecoundaryEconomicActivityBridges)
                    .UsePropertyAccessMode(PropertyAccessMode.Field)
                    .HasField("secoundaryEconomicActivityBridges");

            builder.HasDiscriminator();

            builder.UseTphMappingStrategy();
        }

        private void Configure(OwnedNavigationBuilder<AbstractPDLDevelopmentActorProfile, DevelopmentActorProfileLocationBridge> builder)
        {
            builder.ToTable(LOCATION_BRIDGE_TABLE_NAME);

            builder.Property(entity => entity.MainId)
                .ValueGeneratedNever()
                .HasConversion(id => id.Value, value => new DevelopmentActorProfileId(value));

            builder.Property(entity => entity.LinkedId)
                .ValueGeneratedNever()
                .HasConversion(id => id.Value, value => new Domain.Aggretates.LocationAggregate.Values.LocationId(value));

            builder.HasKey(entity => new { entity.MainId, entity.LinkedId });

            builder.WithOwner().HasForeignKey(entity => entity.MainId);

            builder.HasOne(entity => entity.Linked).WithMany().HasForeignKey(entity => entity.LinkedId).OnDelete(DeleteBehavior.Restrict);
        }

        private void Configure(OwnedNavigationBuilder<AbstractPDLDevelopmentActorProfile, DevelopmentActorProfileProductionActivity> builder)
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

        private void Configure(OwnedNavigationBuilder<AbstractPDLDevelopmentActorProfile, DevelopmentActorProfileCommercialActivity> builder)
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

        private void Configure(OwnedNavigationBuilder<AbstractPDLDevelopmentActorProfile, DevelopmentActorProfileServicingActivity> builder)
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

        private void Configure(OwnedNavigationBuilder<AbstractPDLDevelopmentActorProfile, DevelopmentActorProfileEconomicActivityBridge> builder)
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
    }

    internal sealed class NaturalPDLDevelopmentActorProfileEntityTypeConfiguration : IEntityTypeConfiguration<NaturalOwnedPDLDevelopmentActorProfile>
    {
        public void Configure(EntityTypeBuilder<NaturalOwnedPDLDevelopmentActorProfile> builder)
        {
            builder.Property(entity => entity.HolderPersonId)
                .HasConversion(id => id.Value, value => new Domain.Aggretates.PersonAggregate.Values.PersonId(value));

            builder.HasOne(entity => entity.Holder).WithMany().HasForeignKey(entity => entity.HolderPersonId).OnDelete(DeleteBehavior.Restrict);

            builder.HasBaseType<AbstractPDLDevelopmentActorProfile>();
        }
    }

    internal sealed class LegalPDLDevelopmentActorProfileEntityTypeConfiguration : IEntityTypeConfiguration<LegalOwnedPDLDevelopmentActorProfile>
    {
        public void Configure(EntityTypeBuilder<LegalOwnedPDLDevelopmentActorProfile> builder)
        {
            builder.Property(entity => entity.HolderOrganizationId)
                .HasConversion(id => id.Value, value => new Domain.Aggretates.OrganizationAggregate.Values.OrganizationId(value));

            builder.HasOne(entity => entity.Holder).WithMany().HasForeignKey(entity => entity.HolderOrganizationId).OnDelete(DeleteBehavior.Restrict);

            builder.HasBaseType<AbstractPDLDevelopmentActorProfile>();
        }
    }
}
