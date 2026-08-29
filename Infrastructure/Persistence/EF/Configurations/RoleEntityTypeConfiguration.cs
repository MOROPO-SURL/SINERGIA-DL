using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.RoleAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.RoleAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Persistence.EF.Configurations;

internal class RoleEntityTypeConfiguration : IEntityTypeConfiguration<Role>
{
    private const string TABLE_NAME = "roles";

    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.ToTable(TABLE_NAME);

        builder.HasKey(entity => entity.Id);

        builder.Property(entity => entity.Id)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => new RoleId(value));

        builder.Property(entity => entity.Name)
            .HasMaxLength(120);

        builder.Property(entity => entity.Description)
            .HasMaxLength(480);

        builder.HasIndex(entity => entity.Name);
    }
}
