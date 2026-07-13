using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.ProductAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.ProductAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.ServiceAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Persistence.EF.Converters;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Persistence.EF.Configurations;

internal class ProductEntityTypeConfiguration : IEntityTypeConfiguration<Product>
{
    private const string PRODUCTS_TABLE_NAME = "products";

    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable(PRODUCTS_TABLE_NAME);

        builder.Property(entity => entity.Id)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => new ProductId(value));

        builder.Property(entity => entity.Name)
            .IsRequired()
            .HasMaxLength(1024);

        builder.Property(entity => entity.ImageId)
            .ValueGeneratedNever()
            .HasConversion(new NullableImageIdConverter());

        builder.Property(entity => entity.Description)
            .HasMaxLength(4096);

        builder.HasKey(entity => entity.Id);

        builder.HasOne(entity => entity.Image).WithOne().HasForeignKey<Product>(entity => entity.ImageId).OnDelete(DeleteBehavior.Restrict);
    }
}
