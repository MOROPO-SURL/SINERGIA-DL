using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MOROPO.GEDET.CAM.Domain.Aggretates.OrganizationAggregate;
using MOROPO.GEDET.CAM.Domain.Aggretates.PersonAggregate;
using MOROPO.GEDET.CAM.Domain.Aggretates.PersonAggregate.Values;

namespace MOROPO.GEDET.CAM.Infrastructure.Persistence.EF.Configurations
{
    internal class PersonEntityTypeConfiguration: IEntityTypeConfiguration<Person>
    {
        private const string PERSONS_TABLE_NAME = "persons";

        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable(PERSONS_TABLE_NAME);

            builder.HasKey(entity => entity.Id);

            builder.Property(entity => entity.Id)
                .ValueGeneratedNever()
                .HasConversion(id => id.Value, value => new PersonId(value));

            builder.Property(entity => entity.Name)
                .HasMaxLength(360);

            builder.Property(entity => entity.Alias)
            .HasMaxLength(360);

            builder.Property(entity => entity.LastName)
            .HasMaxLength(360);

            builder.Property(entity => entity.About)
                .HasMaxLength(2048);


            builder.OwnsMany(entity => entity.EmailAddresses);

            builder.OwnsMany(entity => entity.PostalAddresses);

            builder.OwnsMany(entity => entity.WebSites);

            builder.OwnsMany(entity => entity.PhoneNumbers);

            builder.HasOne(entity => entity.Image).WithOne().HasForeignKey<Organization>(entity => entity.ImageId).OnDelete(DeleteBehavior.Cascade);

        }
    }
}
