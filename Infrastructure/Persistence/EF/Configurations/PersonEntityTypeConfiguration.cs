using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.PersonAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.PersonAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Persistence.EF.Converters;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Persistence.EF.Configurations;

internal class PersonEntityTypeConfiguration : IEntityTypeConfiguration<Person>
{
    private const string PERSONS_TABLE_NAME = "people";

    public void Configure(EntityTypeBuilder<Person> builder)
    {
        builder.ToTable(PERSONS_TABLE_NAME);

        builder.HasKey(entity => entity.Id);

        builder.Property(entity => entity.Id)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => new PersonId(value));

        builder.Property(entity => entity.UserId)
            .ValueGeneratedNever()
            .HasConversion(new NullableUserIdConverter());

        builder.Property(entity => entity.Name)
            .HasMaxLength(360);

        builder.Property(entity => entity.Alias)
            .HasMaxLength(360);

        builder.Property(entity => entity.LastName)
            .HasMaxLength(360);

        builder.Property(entity => entity.About)
            .HasMaxLength(2048);

        builder
            .OwnsMany(entity => entity.EmailAddresses, _ => { })
            .Navigation(entity => entity.EmailAddresses)
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasField("emailAddresses");

        builder
            .OwnsMany(entity => entity.PostalAddresses, _ => { })
            .Navigation(entity => entity.PostalAddresses)
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasField("postalAddresses");

        builder
            .OwnsMany(entity => entity.WebSiteAddresses, _ => { })
            .Navigation(entity => entity.WebSiteAddresses)
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasField("webSiteAddresses");

        builder
            .OwnsMany(entity => entity.PhoneNumbers, _ => { })
            .Navigation(entity => entity.PhoneNumbers)
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasField("phoneNumbers");

        builder
            .Navigation(entity => entity.OrganizationBrigdes)
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasField("organizationBrigdes");

        builder.HasOne(entity => entity.Image).WithOne().HasForeignKey<Person>(entity => entity.ImageId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(entity => entity.User).WithOne().HasForeignKey<Person>(entity => entity.UserId).OnDelete(DeleteBehavior.SetNull);
    }
}
