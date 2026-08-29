using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Bridges;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Persistence.EF.Configurations;

internal class RolePermissionBridgeEntityTypeConfiguration : IEntityTypeConfiguration<RolePermissionBridge>
{
    private const string TABLE_NAME = "role_permission_bridges";

    public void Configure(EntityTypeBuilder<RolePermissionBridge> builder)
    {
        builder.ToTable(TABLE_NAME);

        builder.HasKey(bridge => new { bridge.MainId, bridge.LinkedId });

        builder.HasOne(bridge => bridge.Main).WithMany(entity => entity.PermissionBridges).HasForeignKey(bridge => bridge.MainId).OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(bridge => bridge.Linked).WithMany().HasForeignKey(bridge => bridge.LinkedId).OnDelete(DeleteBehavior.Cascade);
    }
}