using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.InterestAreaAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.InterestAreaAggregate;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Persistence.EF.Configurations;

internal class InterestAreaEntityTypeConfiguration : IEntityTypeConfiguration<InterestArea>
{
    private const string INTERESTAREAS_TABLE_NAME = "interestareas";

    public void Configure(EntityTypeBuilder<InterestArea> builder)
    {
        builder.ToTable(INTERESTAREAS_TABLE_NAME);

        builder.HasKey(t => t.Id);

        builder.Property(entity => entity.Id)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => new InterestAreaId(value));

        builder.Property(entity => entity.Name)
            .HasMaxLength(120);

        builder.Property(entity => entity.Description)
            .HasMaxLength(2048);

        builder.HasIndex(t => t.Name).IsUnique();
    }
}
