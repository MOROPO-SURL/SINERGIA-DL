using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.PDLModalityAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.PDLModalityAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Persistence.EF.Configurations;

internal sealed class PDLModalityEntityTypeConfiguration : IEntityTypeConfiguration<PDLModality>
{
    private const string TABLE_NAME = "pdlmodalities";

    public void Configure(EntityTypeBuilder<PDLModality> builder)
    {
        builder.ToTable(TABLE_NAME);

        builder.Property(entity => entity.Id)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => new PDLModalityId(value));

        builder.Property(entity => entity.Name)
            .IsRequired()
            .HasMaxLength(120);

        builder.Property(entity => entity.Description)
            .HasMaxLength(512);

        builder.HasKey(entity => entity.Id);

        builder.HasIndex(entity => entity.Name);
    }
}
