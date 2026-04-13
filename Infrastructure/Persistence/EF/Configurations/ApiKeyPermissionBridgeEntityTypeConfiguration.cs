using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Bridges;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Persistence.EF.Configurations;

internal sealed class ApiKeyPermissionBridgeEntityTypeConfiguration : IEntityTypeConfiguration<ApiKeyPermissionBridge>
{
    private const string TABLE_NAME = "apikey_permission_bridges";

    public void Configure(EntityTypeBuilder<ApiKeyPermissionBridge> builder)
    {
        builder.ToTable(TABLE_NAME);

        builder.HasKey(bridge => new { bridge.MainId, bridge.LinkedId });

        builder.HasOne(bridge => bridge.Main).WithMany(entity => entity.PermissionBridges).HasForeignKey(bridge => bridge.MainId).OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(bridge => bridge.Linked).WithMany().HasForeignKey(bridge => bridge.LinkedId).OnDelete(DeleteBehavior.Cascade);
    }
}