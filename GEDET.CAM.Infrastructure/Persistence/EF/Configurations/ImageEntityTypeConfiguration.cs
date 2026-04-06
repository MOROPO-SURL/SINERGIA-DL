using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MOROPO.GEDET.CAM.Domain.Aggretates.ImageAggregate;

namespace MOROPO.GEDET.CAM.Infrastructure.Persistence.EF.Configurations;

internal class ImageEntityTypeConfiguration : IEntityTypeConfiguration<Image>
{
    private const string TABLE_NAME = "images";

    public void Configure(EntityTypeBuilder<Image> builder)
    {
        builder.ToTable(TABLE_NAME);

        builder.HasKey(entity => entity.Id);

        builder.Property(entity => entity.Id)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => new Domain.Aggretates.ImageAggregate.Values.ImageId(value));

        builder.Property(entity => entity.ContentType)
            .HasMaxLength(60);

        builder.Property(entity => entity.About)
            .HasMaxLength (240);
    }
}
