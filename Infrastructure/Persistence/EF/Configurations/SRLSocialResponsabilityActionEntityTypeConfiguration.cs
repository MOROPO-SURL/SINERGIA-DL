using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.ImageAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.SocialResponsabilityActionAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.SocialResponsabilityActionAggregate.Bridges;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.SocialResponsabilityActionAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.SocialSupportDemandAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Persistence.EF.Configurations;

internal sealed class SRLSocialResponsabilityActionEntityTypeConfiguration : IEntityTypeConfiguration<SRLSocialResponsabilityAction>
{
    private const string TABLE_NAME = "srlsocialresposabilityactions";
    private const string LOCATION_BRIDGE_TABLE_NAME = "srlsocialresposabilityaction_location_bridges";
    private const string IMAGE_BRIDGE_TABLE_NAME = "srlsocialresposabilityaction_image_bridges";

    public void Configure(EntityTypeBuilder<SRLSocialResponsabilityAction> builder)
    {
        builder.ToTable(TABLE_NAME);

        builder.Property(entity => entity.Id)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => new SocialResponsabilityActionId(value));

        builder.Property(entity => entity.OwnerId)
            .HasConversion(id => id.Value, value => new Domain.Aggretates.DevelopmentActorProfileAggregate.Values.DevelopmentActorProfileId(value));

        builder.Property(entity => entity.Title)
            .IsRequired()
            .HasMaxLength(512);

        builder.Property(entity => entity.Description)
            .HasMaxLength(2048);

        builder.Property(entity => entity.DemandId)
            .HasConversion(new NullableSocialSupportDemandIdConverter());

        builder.HasKey(entity => entity.Id);

        builder.HasOne(entity => entity.Owner).WithMany().HasForeignKey(entity => entity.OwnerId).OnDelete(DeleteBehavior.Restrict);

        builder
            .OwnsMany(entity => entity.LocationBridges, Configure)
            .Navigation(entity => entity.LocationBridges)
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasField("locationBridges");

        builder
            .OwnsMany(entity => entity.ImageBridges, Configure)
            .Navigation(entity => entity.ImageBridges)
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasField("imageBridges");
    }

    private static void Configure(OwnedNavigationBuilder<SRLSocialResponsabilityAction, SocialResponsabilityActionLocationBridge> builder)
    {
        builder.ToTable(LOCATION_BRIDGE_TABLE_NAME);

        builder.Property(entity => entity.MainId)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => new SocialResponsabilityActionId(value));

        builder.Property(entity => entity.LinkedId)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => new Domain.Aggretates.LocationAggregate.Values.LocationId(value));

        builder.HasKey(entity => new { entity.MainId, entity.LinkedId });

        builder.WithOwner().HasForeignKey(entity => entity.MainId);

        builder.HasOne(entity => entity.Linked).WithMany().HasForeignKey(entity => entity.LinkedId).OnDelete(DeleteBehavior.Restrict);
    }

    private static void Configure(OwnedNavigationBuilder<SRLSocialResponsabilityAction, SocialResponsabilityActionImageBridge> builder)
    {
        builder.ToTable(IMAGE_BRIDGE_TABLE_NAME);

        builder.Property(entity => entity.MainId)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => new SocialResponsabilityActionId(value));

        builder.Property(entity => entity.LinkedId)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => new ImageId(value));

        builder.HasKey(entity => new { entity.MainId, entity.LinkedId });

        builder.WithOwner().HasForeignKey(entity => entity.MainId);

        builder.HasOne(entity => entity.Linked).WithOne().HasForeignKey<SocialResponsabilityActionImageBridge>(entity => entity.LinkedId).OnDelete(DeleteBehavior.Cascade);
    }

    internal sealed class NullableSocialSupportDemandIdConverter : ValueConverter<SocialSupportDemandId?, Guid?>
    {
        public NullableSocialSupportDemandIdConverter() : base(
            id => id == null ? null : id.Value.Value,
            value => value == null ? null : new SocialSupportDemandId(value.Value))
        {
        }
    }
}
