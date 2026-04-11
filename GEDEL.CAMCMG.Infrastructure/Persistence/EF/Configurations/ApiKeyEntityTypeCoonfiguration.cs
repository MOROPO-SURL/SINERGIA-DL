using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.ApiKeyAggregate;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Persistence.EF.Configurations;

internal sealed class ApiKeyEntityTypeCoonfiguration : IEntityTypeConfiguration<ApiKey>
{
    private const string TABLE_NAME = "apikeys";

    public void Configure(EntityTypeBuilder<ApiKey> builder)
    {
        builder.ToTable(TABLE_NAME);

        builder.HasKey(entity => entity.Id);

        builder.Property(entity => entity.Id)
            .ValueGeneratedNever()
            .HasConversion(key => key.Value, value => new Domain.Aggretates.ApiKeyAggregate.Values.ApiKeyId(value));

        builder.Property(entity => entity.Name)
            .HasMaxLength(240);

        builder.Property(entity => entity.Description)
            .HasMaxLength(480);

        builder.Property(entity => entity.Host)
            .HasMaxLength(120);

        builder.HasIndex(entity => entity.Name);
    }
}
