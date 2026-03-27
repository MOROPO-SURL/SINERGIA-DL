using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MOROPO.GEDET.CAM.Domain.Aggretates.PermissionAggregate;
using MOROPO.GEDET.CAM.Domain.Aggretates.PermissionAggregate.Values;

namespace MOROPO.GEDET.CAM.Infrastructure.Persistence.EF.Configurations;

internal class PermissionEntityTypeConfiguration : IEntityTypeConfiguration<Permission>
{
    private const string TABLE_NAME = "permissions";

    public void Configure(EntityTypeBuilder<Permission> builder)
    {
        builder.ToTable(TABLE_NAME);

        builder.HasKey(entity => entity.Id);

        builder.Property(entity => entity.Id)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => new PermissionId(value));

        builder.Property(entity => entity.Family)
            .HasMaxLength(120);

        builder.Property(entity => entity.Description)
            .HasMaxLength(240);
    }
}
