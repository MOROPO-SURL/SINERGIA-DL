using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MOROPO.GEDET.CAM.Domain.Bridges;
using System.Security.Cryptography;

namespace MOROPO.GEDET.CAM.Infrastructure.Persistence.EF.Configurations;

internal class UserRoleBridgeEntityTypeConfiguration : IEntityTypeConfiguration<UserRoleBridge>
{
    private const string TABLE_NAME = "user_role_bridges";

    public void Configure(EntityTypeBuilder<UserRoleBridge> builder)
    {
        builder.ToTable(TABLE_NAME);

        builder.HasKey(bridge => new { bridge.MainId, bridge.LinkedId });

        builder.Property(bridge => bridge.Signature)
            .HasMaxLength(HMACSHA512.HashSizeInBytes * 2);

        builder.HasOne(bridge => bridge.Main).WithMany(entity => entity.RoleBridges).HasForeignKey(bridge => bridge.MainId).OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(bridge => bridge.Linked).WithMany().HasForeignKey(bridge => bridge.LinkedId).OnDelete(DeleteBehavior.Cascade);
    }
}
