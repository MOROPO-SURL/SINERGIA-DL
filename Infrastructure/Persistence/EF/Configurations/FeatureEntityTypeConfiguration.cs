using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.FeatureAggregate;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Persistence.EF.Configurations;

internal sealed class FeatureEntityTypeConfiguration : IEntityTypeConfiguration<Feature>
{
    private const string TABLE_NAME = "features";

    public void Configure(EntityTypeBuilder<Feature> builder)
    {
        builder.ToTable(TABLE_NAME);

        builder.HasKey(entity => entity.Id);

        builder.Property(entity => entity.Id)
            .ValueGeneratedNever()
            .HasConversion(key => key.Value, value => new Domain.Aggretates.FeatureAggregate.Values.FeatureId(value));

        builder.Property(entity => entity.KindId)
            .ValueGeneratedNever()
            .HasConversion(key => key.Value, value => new Domain.Aggretates.FeatureKindAggregate.Values.FeatureKindId(value));

        builder.Property(entity => entity.Description)
            .HasMaxLength(51200);

        builder.HasOne(entity => entity.Kind).WithOne().HasForeignKey<Feature>(entity => entity.KindId).OnDelete(DeleteBehavior.Restrict);
    }
}
