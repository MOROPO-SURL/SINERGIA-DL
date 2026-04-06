using MOROPO.GEDET.CAM.Domain.Aggretates.ImageAggregate.Values;
using MOROPO.GEDET.CAM.Domain.Aggretates.MacroprogramsAggregate.Values;
using MOROPO.GEDET.CAM.Domain.Aggretates.OrganizationAggregate.Entities;
using MOROPO.GEDET.CAM.Domain.Aggretates.OrganizationAggregate.Values;
using MOROPO.GEDET.CAM.Domain.Bridges;
using MOROPO.GEDET.CAM.Domain.Common.Aggregate;
using MOROPO.GEDET.CAM.Domain.Common.Aggregate.Abstractions;
using MOROPO.GEDET.CAM.Domain.Common.Aggregate.Intefaces;

namespace MOROPO.GEDET.CAM.Domain.Aggretates.OrganizationAggregate;

public class Organization : AbstractAuditableEntity<OrganizationId, Guid>, IAggregateRoot<OrganizationId, Guid>, IArchivableEntity<OrganizationId, Guid>, IEnableableEntity<OrganizationId, Guid>, INamedEntity<OrganizationId, Guid>, IPriorizableEntity<OrganizationId, Guid>
{
    private Organization() : base(new OrganizationId(default)) { }

    public Organization(OrganizationId id, bool isArchived, bool enabled, string name, int priority, Organization owner, OrganizationId? ownerId, ImageAggregate.Image image, OrganizationKind organizationKind, ImageId? imageId, List<EmailAddress> emailAddresses, List<PhoneNumber> phoneNumbers, List<PostalAddress> postalAddresses, List<WebSiteContact> webSites, OrganizationClasificationBridge[] clasificationBridges): base(id)
    {
        IsArchived = isArchived;
        IsEnabled = enabled;
        Name = name;
        Priority = priority;
        Owner = owner;
        OwnerId = ownerId;
        Image = image;
        ImageId = imageId;
        OrganizationKind = organizationKind;
        EmailAddresses = emailAddresses;
        PhoneNumbers = phoneNumbers;
        PostalAddresses = postalAddresses;
        WebSites = webSites;
        ClasificationBridges = [.. clasificationBridges];
    }

    public bool IsArchived { get ; set ; }

    public bool IsEnabled { get ; set ; }
    
    public string Name { get; set; } = null!;
    
    public int Priority { get ; set ; }

    public Organization? Owner { get; set; }
    public OrganizationId? OwnerId { get; set; }

    public ImageAggregate.Image? Image { get; set; }
    public ImageId? ImageId { get; set; }

    public OrganizationKind OrganizationKind { get; set; } = null!;
    public OrganizationKindId OrganizationKindId { get; set; }

    public List<EmailAddress> EmailAddresses { get; set; } = null!;

    public List<PhoneNumber> PhoneNumbers { get; set; } = null!;

    public List<PostalAddress> PostalAddresses { get; set; } = null!;

    public List<WebSiteContact> WebSites { get; set; } = null!;

    public List<OrganizationClasificationBridge> ClasificationBridges { get; set; } = null!;
}
