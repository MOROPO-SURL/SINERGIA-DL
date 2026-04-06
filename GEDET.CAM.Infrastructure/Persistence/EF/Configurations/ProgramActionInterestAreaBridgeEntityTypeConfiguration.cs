using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MOROPO.GEDET.CAM.Domain.Bridges;

namespace MOROPO.GEDET.CAM.Infrastructure.Persistence.EF.Configurations
{
    internal class ProgramActionInterestAreaBridgeEntityTypeConfiguration: IEntityTypeConfiguration<ProgramActionInterestAreaBridge>
    {
        private const string TABLE_NAME = "programaction_interestarea_bridges";

        public void Configure(EntityTypeBuilder<ProgramActionInterestAreaBridge> builder)
        {
            builder.ToTable(TABLE_NAME);

            builder.HasKey(bridge => new { bridge.MainId, bridge.LinkedId });

            builder.HasOne(bridge => bridge.Main).WithMany(entity => entity.InterestAreaBridges).HasForeignKey(bridge => bridge.MainId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(bridge => bridge.Linked).WithMany().HasForeignKey(bridge => bridge.LinkedId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
