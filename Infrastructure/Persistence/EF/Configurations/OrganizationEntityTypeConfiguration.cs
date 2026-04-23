using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.OrganizationAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.OrganizationAggregate;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Persistence.EF.Configurations;

internal class OrganizationEntityTypeConfiguration : IEntityTypeConfiguration<Organization>
{
    private const string TABLE_NAME = "organizations";

    public void Configure(EntityTypeBuilder<Organization> builder)
    {
        builder.ToTable(TABLE_NAME);

        builder.HasKey(entity => entity.Id);

        builder.Property(entity => entity.Id)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => new OrganizationId(value));

        builder.Property(entity => entity.Name)
            .HasMaxLength(360);

        builder.OwnsMany(entity => entity.EmailAddresses);

        builder.OwnsMany(entity => entity.PostalAddresses);

        builder.OwnsMany(entity => entity.WebSiteAddresses);

        builder.OwnsMany(entity => entity.PhoneNumbers);

        builder.HasOne(entity => entity.Image).WithOne().HasForeignKey<Organization>(entity => entity.ImageId).OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(entity => entity.Owner).WithOne().HasForeignKey<Organization>(entity => entity.OwnerId).OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(entity => entity.OrganizationKind).WithMany().HasForeignKey(entity => entity.OrganizationKindId).OnDelete(DeleteBehavior.Restrict);
    }
}
