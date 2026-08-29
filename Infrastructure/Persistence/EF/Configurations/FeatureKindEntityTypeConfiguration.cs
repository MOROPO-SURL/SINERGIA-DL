using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.FeatureKindAggregate;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Persistence.EF.Configurations;

internal sealed class FeatureKindEntityTypeConfiguration : IEntityTypeConfiguration<FeatureKind>
{
    private const string TABLE_NAME = "featurekinds";

    public void Configure(EntityTypeBuilder<FeatureKind> builder)
    {
        builder.ToTable(TABLE_NAME);

        builder.HasKey(entity => entity.Id);

        builder.Property(entity => entity.Id)
            .ValueGeneratedNever()
            .HasConversion(key => key.Value, value => new Domain.Aggretates.FeatureKindAggregate.Values.FeatureKindId(value));

        builder.Property(entity => entity.Name)
            .HasMaxLength(360);

        builder.Property(entity => entity.Description)
            .HasMaxLength(1024);
    }
}
