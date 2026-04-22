using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.ImageAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.ImageAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.OrganizationAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.OrganizationKindAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.OrganizationKindAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Bridges;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Common.Aggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Common.Aggregate.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Common.Aggregate.Intefaces;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.OrganizationAggregate;

public class Organization : AbstractAuditableEntity<OrganizationId, Guid>, IAggregateRoot<OrganizationId, Guid>, IArchivableEntity<OrganizationId, Guid>, IEnableableEntity<OrganizationId, Guid>, INamedEntity<OrganizationId, Guid>, IPriorizableEntity<OrganizationId, Guid>
{
    private Organization() : base(new OrganizationId(default)) { }

    public Organization(OrganizationId id, bool isArchived, bool enabled, string name, int priority, OrganizationKindId organizationKindId, List<EmailAddress> emailAddresses, List<PhoneNumber> phoneNumbers, List<PostalAddress> postalAddresses, List<WebSiteAddress> webSites, OrganizationKind? organizationKind = null, Organization? owner = null, OrganizationId? ownerId = null, Image? image = null, ImageId? imageId = null) : base(id)
    {
        IsArchived = isArchived;
        IsEnabled = enabled;
        Name = name;
        Priority = priority;
        Owner = owner;
        OwnerId = ownerId;
        Image = image;
        ImageId = imageId;
        OrganizationKindId = organizationKindId;
        OrganizationKind = organizationKind;
        EmailAddresses = emailAddresses;
        PhoneNumbers = phoneNumbers;
        PostalAddresses = postalAddresses;
        WebSites = webSites;
    }

    public bool IsArchived { get; set; }

    public bool IsEnabled { get; set; }

    public string Name { get; set; } = null!;

    public int Priority { get; set; }

    public Organization? Owner { get; set; }
    public OrganizationId? OwnerId { get; set; }

    public Image? Image { get; set; }
    public ImageId? ImageId { get; set; }

    public OrganizationKind? OrganizationKind { get; set; }
    public OrganizationKindId OrganizationKindId { get; set; }

    public List<EmailAddress> EmailAddresses { get; set; } = null!;

    public List<PhoneNumber> PhoneNumbers { get; set; } = null!;

    public List<PostalAddress> PostalAddresses { get; set; } = null!;

    public List<WebSiteAddress> WebSites { get; set; } = null!;

    public List<OrganizationClasificationBridge> ClasificationBridges { get; set; } = [];
}
