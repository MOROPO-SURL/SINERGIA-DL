using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.ClassificationAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.ClassificationAggregate;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Persistence.EF.Configurations;

internal class ClassificationEntityTypeConfiguration : IEntityTypeConfiguration<Classification>
{
    private const string TABLE_NAME = "classifications";

    public void Configure(EntityTypeBuilder<Classification> builder)
    {
        builder.ToTable(TABLE_NAME);

        builder.HasKey(t => t.Id);

        builder.Property(entity => entity.Id)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => new ClassificationId(value));

        builder.Property(entity => entity.Name)
            .HasMaxLength(120);

        builder.Property(entity => entity.Description)
            .HasMaxLength(2048);

        builder.HasIndex(t => t.Name).IsUnique();
    }
}


