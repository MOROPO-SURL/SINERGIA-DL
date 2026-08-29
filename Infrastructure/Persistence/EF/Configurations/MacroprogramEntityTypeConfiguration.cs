using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.MacroprogramAggregate.Values;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.MacroprogramAggregate;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Persistence.EF.Configurations;

internal class MacroprogramEntityTypeConfiguration : IEntityTypeConfiguration<Macroprogram>
{
    private const string TABLE_NAME = "macroprograms";

    public void Configure(EntityTypeBuilder<Macroprogram> builder)
    {
        builder.ToTable(TABLE_NAME);

        builder.HasKey(t => t.Id);

        builder.Property(entity => entity.Id)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => new MacroprogramId(value));

        builder.Property(entity => entity.Title)
            .HasMaxLength(360);

        builder.Property(entity => entity.Description)
            .HasMaxLength(2048);

        builder.HasIndex(entity => entity.Index).IsUnique();
    }
}
