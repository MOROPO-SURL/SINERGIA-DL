using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.SocialSupportDemandAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.SocialSupportDemandAggregate.Bridges;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.SocialSupportDemandAggregate.Entities;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Persistence.EF.Configurations;

internal sealed class SocialSupportDemandEntityTypeConfiguration : IEntityTypeConfiguration<SocialSupportDemand>
{
    private const string TABLE_NAME = "socialsupportdemands";
    private const string LOCATION_TABLE_NAME = "socialsupportdemand_locations";
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
            .OwnsMany(entity => entity.Locations, Configure)
            .Navigation(entity => entity.Locations)
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasField("locations");

        builder
            .OwnsMany(entity => entity.ImageBridges, Configure)
            .Navigation(entity => entity.ImageBridges)
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasField("imageBridges");
    }

    public void Configure(OwnedNavigationBuilder<SocialSupportDemand, Location> builder)
    {
        builder.ToTable(LOCATION_TABLE_NAME);

        builder.Property(entity => entity.Id)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => new Domain.Aggretates.SocialSupportDemandAggregate.Values.LocationId(value));

        builder.Property(entity => entity.SocialSupportDemandId)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => new Domain.Aggretates.SocialSupportDemandAggregate.Values.SocialSupportDemandId(value));

        builder.Property(entity => entity.Name)
            .IsRequired()
            .HasMaxLength(512);

        builder.Property(entity => entity.FeatureImageId)
            .HasConversion(new Converters.NullableImageIdConverter());

        builder.Property(entity => entity.Description)
            .HasMaxLength(2048);

        builder.HasKey(entity => new { entity.Id, entity.SocialSupportDemandId });

        builder.WithOwner().HasForeignKey(entity => entity.SocialSupportDemandId);

        builder.OwnsOne(entity => entity.Coordinate);

        builder.OwnsOne(entity => entity.PostalAddress);

        builder.HasOne(entity => entity.FeatureImage).WithOne().HasForeignKey<Location>(entity => entity.FeatureImageId).OnDelete(DeleteBehavior.Cascade);
    }

    public void Configure(OwnedNavigationBuilder<SocialSupportDemand, SocialSupportDemandImageBridge> builder) 
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
