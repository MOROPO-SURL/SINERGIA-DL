using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.LocationAggregate;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Persistence.EF.Configurations;

internal sealed class LocationEntityTypeConfiguration : IEntityTypeConfiguration<Location>
{
    private const string TABLE_NAME = "locations";

    public void Configure(EntityTypeBuilder<Location> builder)
    {
        builder.ToTable(TABLE_NAME);

        builder.Property(entity => entity.Id)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => new Domain.Aggretates.LocationAggregate.Values.LocationId(value));

        builder.Property(entity => entity.Name)
            .IsRequired()
            .HasMaxLength(512);

        builder.Property(entity => entity.FeatureImageId)
            .HasConversion(new Converters.NullableImageIdConverter());

        builder.Property(entity => entity.Description)
            .HasMaxLength(2048);

        builder.HasKey(entity => entity.Id);

        builder.OwnsOne(entity => entity.Coordinate);

        builder.OwnsOne(entity => entity.PostalAddress);

        builder.HasOne(entity => entity.FeatureImage).WithOne().HasForeignKey<Location>(entity => entity.FeatureImageId).OnDelete(DeleteBehavior.Cascade);
    }
}
