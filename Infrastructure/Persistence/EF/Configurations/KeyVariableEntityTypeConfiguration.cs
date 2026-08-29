using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.KeyVariableAggregate.Values;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.KeyVariableAggregate;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Persistence.EF.Configurations;

internal class KeyVariableEntityTypeConfiguration : IEntityTypeConfiguration<KeyVariable>
{
    private const string TABLE_NAME = "keyvariables";

    public void Configure(EntityTypeBuilder<KeyVariable> builder)
    {
        builder.ToTable(TABLE_NAME);

        builder.HasKey(entity => entity.Id);

        builder.Property(entity => entity.Id)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => new KeyVariableId(value));

        builder.Property(entity => entity.Name)
            .HasMaxLength(120);

        builder.Property(entity => entity.Alias)
            .HasMaxLength(60);

        builder.Property(entity => entity.Description)
            .HasMaxLength(480);

        builder.HasIndex(entity => entity.Name);
        builder.HasIndex(entity => entity.Alias);
    }
}
