using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.OrganizationAggregate.Values;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.OrganizationAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.OrganizationAggregate.Bridges;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Persistence.EF.Configurations;

internal class OrganizationEntityTypeConfiguration : IEntityTypeConfiguration<Organization>
{
    private const string ROOT_TABLE_NAME = "organizations";
    private const string CLASSIFICATION_BRIDGE_TABLE_NAME = "organization_classification_bridges";

    public void Configure(EntityTypeBuilder<Organization> builder)
    {
        builder.ToTable(ROOT_TABLE_NAME);

        builder.HasKey(entity => entity.Id);

        builder.Property(entity => entity.Id)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => new OrganizationId(value));

        builder.Property(entity => entity.Name)
            .HasMaxLength(360);

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
            .OwnsMany(entity => entity.ClassificationBridges, Configure)
            .Navigation(entity => entity.ClassificationBridges)
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasField("classificationBridges");

        builder
            .Navigation(entity => entity.PersonBridges)
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasField("personBrigdes");

        builder.HasOne(entity => entity.Image).WithOne().HasForeignKey<Organization>(entity => entity.ImageId).OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(entity => entity.Owner).WithOne().HasForeignKey<Organization>(entity => entity.OwnerId).OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(entity => entity.Kind).WithMany().HasForeignKey(entity => entity.KindId).OnDelete(DeleteBehavior.Restrict);
    }

    private void Configure(OwnedNavigationBuilder<Organization, OrganizationClassificationBridge> builder)
    {
        builder.ToTable(CLASSIFICATION_BRIDGE_TABLE_NAME);

        builder.HasKey(bridge => new { bridge.MainId, bridge.LinkedId });

        builder.WithOwner().HasForeignKey(bridge => bridge.MainId);

        builder.HasOne(bridge => bridge.Linked).WithMany().HasForeignKey(bridge => bridge.LinkedId).OnDelete(DeleteBehavior.Cascade);
    }
}
