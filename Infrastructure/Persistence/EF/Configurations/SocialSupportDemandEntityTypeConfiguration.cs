using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.SocialSupportDemandAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.SocialSupportDemandAggregate.Bridges;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Persistence.EF.Configurations;

internal sealed class SocialSupportDemandEntityTypeConfiguration : IEntityTypeConfiguration<SocialSupportDemand>
{
    private const string TABLE_NAME = "socialsupportdemands";
    private const string LOCATION_BRIDGE_TABLE_NAME = "socialsupportdemand_location_bridges";
    private const string IMAGE_BRIDGE_TABLE_NAME = "socialsupportdemand_image_bridges";

    public void Configure(EntityTypeBuilder<SocialSupportDemand> builder)
    {
        builder.ToTable(TABLE_NAME);

        builder.Property(entity => entity.Id)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => new Domain.Aggretates.SocialSupportDemandAggregate.Values.SocialSupportDemandId(value));

        builder.Property(entity => entity.Title)
            .IsRequired()
            .HasMaxLength(512);

        builder.Property(entity => entity.Description)
            .HasMaxLength(2048);

        builder.HasKey(entity => entity.Id);

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

    private static void Configure(OwnedNavigationBuilder<SocialSupportDemand, SocialSupportDemandLocationBridge> builder)
    {
        builder.ToTable(LOCATION_BRIDGE_TABLE_NAME);

        builder.Property(entity => entity.MainId)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => new Domain.Aggretates.SocialSupportDemandAggregate.Values.SocialSupportDemandId(value));

        builder.Property(entity => entity.LinkedId)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => new Domain.Aggretates.LocationAggregate.Values.LocationId(value));

        builder.HasKey(entity => new { entity.MainId, entity.LinkedId });

        builder.WithOwner().HasForeignKey(entity => entity.MainId);

        builder.HasOne(entity => entity.Linked).WithMany().HasForeignKey(entity => entity.LinkedId).OnDelete(DeleteBehavior.Restrict);
    }

    private static void Configure(OwnedNavigationBuilder<SocialSupportDemand, SocialSupportDemandImageBridge> builder) 
    {
        builder.ToTable(IMAGE_BRIDGE_TABLE_NAME);

        builder.Property(entity => entity.MainId)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => new Domain.Aggretates.SocialSupportDemandAggregate.Values.SocialSupportDemandId(value));

        builder.Property(entity => entity.LinkedId)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => new Domain.Aggretates.ImageAggregate.Values.ImageId(value));

        builder.HasKey(entity => new { entity.MainId, entity.LinkedId });

        builder.WithOwner().HasForeignKey(entity => entity.MainId);

        builder.HasOne(entity => entity.Linked).WithOne().HasForeignKey<SocialSupportDemandImageBridge>(entity => entity.LinkedId).OnDelete(DeleteBehavior.Cascade);
    }
}