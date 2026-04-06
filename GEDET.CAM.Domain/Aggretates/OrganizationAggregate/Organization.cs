using MOROPO.GEDET.CAM.Domain.Aggretates.ImageAggregate.Values;
using MOROPO.GEDET.CAM.Domain.Aggretates.OrganizationAggregate.Values;
using MOROPO.GEDET.CAM.Domain.Common.Aggregate;
using MOROPO.GEDET.CAM.Domain.Common.Aggregate.Abstractions;
using MOROPO.GEDET.CAM.Domain.Common.Aggregate.Intefaces;

namespace MOROPO.GEDET.CAM.Domain.Aggretates.OrganizationAggregate;

public class Organization : AbstractAuditableEntity<OrganizationId, Guid>, IAggregateRoot<OrganizationId, Guid>, IArchivableEntity<OrganizationId, Guid>, IEnableableEntity<OrganizationId, Guid>, INamedEntity<OrganizationId, Guid>, IPriorizableEntity<OrganizationId, Guid>
{
    public Organization(OrganizationId id, bool isArchived, bool enabled, string name, int priority, Organization owner, OrganizationId? ownerId, ImageAggregate.Image image, ImageId? imageId, List<EmailAddress> emailAddresses, List<PhoneNumber> phoneNumbers, List<PostalAddress> postalAddresses, List<WebSiteContact> webSites): base(id)
    {
        IsArchived = isArchived;
        IsEnabled = enabled;
        Name = name;
        Priority = priority;
        Owner = owner;
        OwnerId = ownerId;
        Image = image;
        ImageId = imageId;
        EmailAddresses = emailAddresses;
        PhoneNumbers = phoneNumbers;
        PostalAddresses = postalAddresses;
        WebSites = webSites;
    }

    public bool IsArchived { get ; set ; }

    public bool IsEnabled { get ; set ; }
    
    public string Name { get ; set ; }
    
    public int Priority { get ; set ; }

    public Organization? Owner { get; set; }
    public OrganizationId? OwnerId { get; set; }

    public ImageAggregate.Image? Image { get; set; }
    public ImageId? ImageId { get; set; }

    public List<EmailAddress> EmailAddresses { get; set; }

    public List<PhoneNumber> PhoneNumbers { get; set; }

    public List<PostalAddress> PostalAddresses { get; set; }

    public List<WebSiteContact> WebSites { get; set; }
}