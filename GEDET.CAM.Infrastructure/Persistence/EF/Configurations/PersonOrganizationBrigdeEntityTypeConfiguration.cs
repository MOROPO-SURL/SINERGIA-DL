using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MOROPO.GEDET.CAM.Domain.Bridges;

namespace MOROPO.GEDET.CAM.Infrastructure.Persistence.EF.Configurations
{
    internal class PersonOrganizationBrigdeEntityTypeConfiguration: IEntityTypeConfiguration<PersonOrganizationBrigde>
    {
        private const string TABLE_NAME = "person_organization_bridges";

        public void Configure(EntityTypeBuilder<PersonOrganizationBrigde> builder)
        {
            builder.ToTable(TABLE_NAME);

            builder.HasKey(bridge => new { bridge.MainId, bridge.LinkedId });

            builder.HasOne(bridge => bridge.Main).WithMany(entity => entity.OrganizationBrigde).HasForeignKey(bridge => bridge.MainId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(bridge => bridge.Linked).WithMany().HasForeignKey(bridge => bridge.LinkedId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
