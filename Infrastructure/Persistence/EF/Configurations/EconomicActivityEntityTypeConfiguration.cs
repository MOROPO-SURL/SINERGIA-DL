using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.EconomicActivityAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.EconomicActivityAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Persistence.EF.Configurations;

internal sealed class EconomicActivityEntityTypeConfiguration : IEntityTypeConfiguration<EconomicActivity>
{
    private const string TABLE_NAME = "economicactivities";

    public void Configure(EntityTypeBuilder<EconomicActivity> builder)
    {
        builder.ToTable(TABLE_NAME);

        builder.Property(entity => entity.Id)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => new EconomicActivityId(value));

        builder.Property(entity => entity.Name)
            .IsRequired()
            .HasMaxLength(1024);

        builder.HasKey(entity => entity.Id);
    }
}
