using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MOROPO.GEDET.CAM.Domain.Aggretates.RoleAggregate;
using MOROPO.GEDET.CAM.Domain.Aggretates.RoleAggregate.Values;

namespace MOROPO.GEDET.CAM.Infrastructure.Persistence.EF.Configurations;

internal class RoleEntityTypeConfiguration : IEntityTypeConfiguration<Role>
{
    private const string ROOT_TABLE_NAME = "roles";

    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.ToTable(ROOT_TABLE_NAME);

        builder.HasKey(t => t.Id);

        builder.Property(entity => entity.Id)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => new RoleId(value));

        builder.Property(entity => entity.Name)
            .HasMaxLength(120);

        builder.HasIndex(t => t.Name);
    }
}
