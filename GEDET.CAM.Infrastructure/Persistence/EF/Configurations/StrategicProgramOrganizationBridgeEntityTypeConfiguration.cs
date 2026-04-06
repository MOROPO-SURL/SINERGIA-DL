using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MOROPO.GEDET.CAM.Domain.Bridges;

namespace MOROPO.GEDET.CAM.Infrastructure.Persistence.EF.Configurations
{
    internal class StrategicProgramOrganizationBridgeEntityTypeConfiguration: IEntityTypeConfiguration<StrategicProgramOrganizationBridge>
    {
        private const string TABLE_NAME = "strategicprogram_organization_bridges";

        public void Configure(EntityTypeBuilder<StrategicProgramOrganizationBridge> builder)
        {
            builder.ToTable(TABLE_NAME);

            builder.HasKey(bridge => new { bridge.MainId, bridge.LinkedId });

            builder.HasOne(bridge => bridge.Main).WithMany(entity => entity.OrganizationBridges).HasForeignKey(bridge => bridge.MainId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(bridge => bridge.Linked).WithMany().HasForeignKey(bridge => bridge.LinkedId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
