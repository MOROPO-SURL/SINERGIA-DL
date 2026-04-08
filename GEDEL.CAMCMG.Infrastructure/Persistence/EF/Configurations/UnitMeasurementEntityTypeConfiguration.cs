using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.UnitMeasurementAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.UnitMeasurementAggregate;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Persistence.EF.Configurations;

internal class UnitMeasurementEntityTypeConfiguration : IEntityTypeConfiguration<UnitMeasurement>
{
    private const string UNITMEASUREMENTS_TABLE_NAME = "unit_measurements";

    public void Configure(EntityTypeBuilder<UnitMeasurement> builder)
    {
        builder.ToTable(UNITMEASUREMENTS_TABLE_NAME);

        builder.HasKey(entity => entity.Id);

        builder.Property(entity => entity.Id)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => new UnitMeasurementId(value));

        builder.Property(entity => entity.Name)
            .HasMaxLength(360);

        builder.Property(entity => entity.Symbol)
            .HasMaxLength(360);

        builder.HasIndex(entity => entity.Name);

    }
}
