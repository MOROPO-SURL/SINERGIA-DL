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
    private readonly List<EmailAddress> emailAddresses = [];

    private readonly List<PhoneNumber> phoneNumbers = [];

    private readonly List<PostalAddress> postalAddresses = [];

    private readonly List<WebSiteAddress> webSiteAddresses = [];

    private Organization() : base(new OrganizationId(default)) { }

    public Organization(OrganizationId id, bool isArchived, bool enabled, string name, int priority, OrganizationKindId organizationKindId, EmailAddress[] emailAddresses, PhoneNumber[] phoneNumbers, PostalAddress[] postalAddresses, WebSiteAddress[] webSiteAddresses, OrganizationKind? organizationKind = null, Organization? owner = null, OrganizationId? ownerId = null, string? about = null, Image? image = null, ImageId? imageId = null) : base(id)
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
        About = about;

        this.emailAddresses = [.. emailAddresses];
        this.phoneNumbers = [.. phoneNumbers];
        this.postalAddresses = [.. postalAddresses];
        this.webSiteAddresses = [.. webSiteAddresses];
    }

    public bool IsArchived { get; set; }

    public bool IsEnabled { get; set; }

    public string Name { get; set; } = null!;

    public int Priority { get; set; }

    public string? About { get; set; }

    public Organization? Owner { get; set; }
    public OrganizationId? OwnerId { get; set; }

    public Image? Image { get; set; }
    public ImageId? ImageId { get; set; }

    public OrganizationKind? OrganizationKind { get; set; }
    public OrganizationKindId OrganizationKindId { get; set; }

    public IReadOnlyList<EmailAddress> EmailAddresses => [.. emailAddresses];

    public IReadOnlyList<PhoneNumber> PhoneNumbers => [.. phoneNumbers];

    public IReadOnlyList<PostalAddress> PostalAddresses => [.. postalAddresses];

    public IReadOnlyList<WebSiteAddress> WebSiteAddresses => [.. webSiteAddresses];

    public List<OrganizationClasificationBridge> ClasificationBridges { get; set; } = [];

    public void Add(EmailAddress value)
    {
        emailAddresses.Add(value);
    }

    public void Remove(EmailAddress value)
    {
        emailAddresses.Remove(value);
    }

    public void Add(PhoneNumber value)
    {
        phoneNumbers.Add(value);
    }

    public void Remove(PhoneNumber value)
    {
        phoneNumbers.Remove(value);
    }

    public void Add(PostalAddress value)
    {
        postalAddresses.Add(value);
    }

    public void Remove(PostalAddress value)
    {
        postalAddresses.Remove(value);
    }

    public void Add(WebSiteAddress value)
    {
        webSiteAddresses.Add(value);
    }

    public void Remove(WebSiteAddress value)
    {
        webSiteAddresses.Remove(value);
    }
}
