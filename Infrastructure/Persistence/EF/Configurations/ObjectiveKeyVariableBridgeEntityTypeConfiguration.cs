using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Bridges;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Persistence.EF.Configurations;

internal class ObjectiveKeyVariableBridgeEntityTypeConfiguration : IEntityTypeConfiguration<ObjectiveKeyVariableBridge>
{
    private const string TABLE_NAME = "objective_keyvariable_bridges";

    public void Configure(EntityTypeBuilder<ObjectiveKeyVariableBridge> builder)
    {
        builder.ToTable(TABLE_NAME);

        builder.HasKey(bridge => new { bridge.MainId, bridge.LinkedId });

        builder.HasOne(bridge => bridge.Main).WithMany(entity => entity.KeyVariableBridges).HasForeignKey(bridge => bridge.MainId).OnDelete(DeleteBehavior.Cascade);
        builder.HasOne(bridge => bridge.Linked).WithMany().HasForeignKey(bridge => bridge.LinkedId).OnDelete(DeleteBehavior.Cascade);
    }
}
