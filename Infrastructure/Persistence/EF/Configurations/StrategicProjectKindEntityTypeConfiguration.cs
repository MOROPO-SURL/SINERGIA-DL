using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.StrategicProjectKindAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.StrategicProjectKindAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Persistence.EF.Configurations;

internal sealed class StrategicProjectKindEntityTypeConfiguration : IEntityTypeConfiguration<StrategicProjectKind>
{
    private const string TABLE_NAME = "strategicprojectkinds";

    public void Configure(EntityTypeBuilder<StrategicProjectKind> builder)
    {
        builder.ToTable(TABLE_NAME);

        builder.HasKey(entity => entity.Id);

        builder.Property(entity => entity.Id)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => new StrategicProjectKindId(value));

        builder.Property(entity => entity.Name)
            .HasMaxLength(120);

        builder.Property(entity => entity.Description)
            .HasMaxLength(480);

        builder.HasIndex(entity => entity.Name).IsUnique();
    }
}