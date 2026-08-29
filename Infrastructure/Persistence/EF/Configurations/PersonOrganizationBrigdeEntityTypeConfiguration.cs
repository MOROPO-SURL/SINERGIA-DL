using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Bridges;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Persistence.EF.Configurations;

internal class PersonOrganizationBrigdeEntityTypeConfiguration : IEntityTypeConfiguration<PersonOrganizationBrigde>
{
    private const string TABLE_NAME = "person_organization_bridges";

    public void Configure(EntityTypeBuilder<PersonOrganizationBrigde> builder)
    {
        builder.ToTable(TABLE_NAME);

        builder.HasKey(bridge => new { bridge.MainId, bridge.LinkedId });

        builder.HasOne(bridge => bridge.Main).WithMany(entity => entity.OrganizationBrigdes).HasForeignKey(bridge => bridge.MainId).OnDelete(DeleteBehavior.Cascade);
        builder.HasOne(bridge => bridge.Linked).WithMany(entity => entity.PersonBridges).HasForeignKey(bridge => bridge.LinkedId).OnDelete(DeleteBehavior.Cascade);
    }
}
