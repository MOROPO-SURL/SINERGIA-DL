using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.ServiceAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.ServiceAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Persistence.EF.Configurations;

internal sealed class ServiceEntityTypeConfigurator : IEntityTypeConfiguration<Service>
{
    private const string TABLE_NAME = "services";

    public void Configure(EntityTypeBuilder<Service> builder)
    {
        builder.ToTable(TABLE_NAME);

        builder.Property(entity => entity.Id)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => new ServiceId(value));

        builder.Property(entity => entity.Name)
            .IsRequired()
            .HasMaxLength(1024);

        builder.Property(entity => entity.ImageId)
            .ValueGeneratedNever()
            .HasConversion(new Converters.NullableImageIdConverter());

        builder.Property(entity => entity.Description)
            .HasMaxLength(4096);

        builder.HasKey(entity => entity.Id);

        builder.HasOne(entity => entity.Image).WithOne().HasForeignKey<Service>(entity => entity.ImageId).OnDelete(DeleteBehavior.Restrict);
    }
}
