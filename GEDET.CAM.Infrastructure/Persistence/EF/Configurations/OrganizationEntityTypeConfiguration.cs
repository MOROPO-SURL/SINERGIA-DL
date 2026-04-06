using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MOROPO.GEDET.CAM.Domain.Aggretates.ObjectiveAggregate;
using MOROPO.GEDET.CAM.Domain.Aggretates.ObjectiveAggregate.Entities;
using MOROPO.GEDET.CAM.Domain.Aggretates.ObjectiveAggregate.Values;
using MOROPO.GEDET.CAM.Domain.Aggretates.OrganizationAggregate;
using MOROPO.GEDET.CAM.Domain.Aggretates.OrganizationAggregate.Entities;
using MOROPO.GEDET.CAM.Domain.Aggretates.OrganizationAggregate.Values;

namespace MOROPO.GEDET.CAM.Infrastructure.Persistence.EF.Configurations
{
    internal class OrganizationEntityTypeConfiguration: IEntityTypeConfiguration<Organization>
    {
        private const string ORGANIZATIONS_TABLE_NAME = "organizations";

        public void Configure(EntityTypeBuilder<Organization> builder)
        {
            builder.ToTable(ORGANIZATIONS_TABLE_NAME);

            builder.HasKey(entity => entity.Id);

            builder.Property(entity => entity.Id)
                .ValueGeneratedNever()
                .HasConversion(id => id.Value, value => new OrganizationId(value));

            builder.Property(entity => entity.Name)
                .HasMaxLength(360);

            builder.OwnsMany(entity => entity.EmailAddresses);

            builder.OwnsMany(entity => entity.PostalAddresses);

            builder.OwnsMany(entity => entity.WebSites);

            builder.OwnsMany(entity => entity.PhoneNumbers);

            builder.HasOne(entity => entity.Image).WithOne().HasForeignKey<Organization>(entity => entity.ImageId).OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(entity => entity.Owner).WithOne().HasForeignKey<Organization>(entity => entity.OwnerId).OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(entity => entity.OrganizationKind).WithMany().HasForeignKey(entity => entity.OrganizationKindId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
