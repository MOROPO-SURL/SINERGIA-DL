using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.ImageAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.ImageAggregate.Values;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.OrganizationAggregate.Values;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.PersonAggregate.Enumerations;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.PersonAggregate.Values;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.UserAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.UserAggregate.Values;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Bridges;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Common.Aggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Common.Aggregate.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Common.Aggregate.Intefaces;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.PersonAggregate;

public class Person : AbstractAuditableEntity<PersonId, Guid>, IAggregateRoot<PersonId, Guid>, INamedEntity<PersonId, Guid>, IArchivableEntity<PersonId, Guid>, IEnableableEntity<PersonId, Guid>, IPriorizableEntity<PersonId, Guid>
{
    private readonly List<EmailAddress> emailAddresses = [];
    private readonly List<PhoneNumber> phoneNumbers = [];
    private readonly List<PostalAddress> postalAddresses = [];
    private readonly List<WebSiteAddress> webSiteAddresses = [];
    private readonly List<PersonOrganizationBrigde> organizationBrigdes = [];

    private Person() : base(new PersonId(default)) { }

    public Person(
        PersonId id, 
        int priority, 
        bool isEnabled, 
        bool isArchived, 
        string name, 
        Sex sex, 
        CivilStatus civilStatus,
        IEnumerable<EmailAddress> emailAddresses,
        IEnumerable<PhoneNumber> phoneNumbers,
        IEnumerable<PostalAddress> postalAddresses,
        IEnumerable<WebSiteAddress> webSiteAddresses,
        IEnumerable<PersonOrganizationBrigde> organizationBrigdes, 
        string? lastName = null, 
        string? alias = null, 
        DateTime? bornDate = null, 
        string? about = null,
        ImageId? imageId = null, 
        Image? image = null,
        UserId? userId = null,
        User? user = null) : base(id)
    {
        Alias = alias;
        BornDate = bornDate;
        About = about;
        Priority = priority;
        IsEnabled = isEnabled;
        IsArchived = isArchived;
        Name = name;
        LastName = lastName;
        Sex = sex;
        CivilStatus = civilStatus;
        ImageId = imageId;
        Image = image;
        UserId = userId;
        User = user;

        this.emailAddresses = [.. emailAddresses];
        this.phoneNumbers = [.. phoneNumbers];
        this.postalAddresses = [.. postalAddresses];
        this.webSiteAddresses = [.. webSiteAddresses];
        this.organizationBrigdes = [.. organizationBrigdes];
    }

    public string? Alias { get; set; }

    public DateTime? BornDate { get; set; }

    public string? About { get; set; }

    public int Priority { get; set; }

    public bool IsEnabled { get; set; }

    public bool IsArchived { get; set; }

    public string Name { get; set; } = null!;

    public string? LastName { get; set; }

    public Sex Sex { get; set; }

    public CivilStatus CivilStatus { get; set; }

    public Image? Image { get; set; }
    public ImageId? ImageId { get; set; }

    public UserId? UserId { get; set; }
    public User? User { get; set; }

    public IReadOnlyList<EmailAddress> EmailAddresses => [.. emailAddresses];

    public IReadOnlyList<PhoneNumber> PhoneNumbers => [.. phoneNumbers];

    public IReadOnlyList<PostalAddress> PostalAddresses => [.. postalAddresses];

    public IReadOnlyList<WebSiteAddress> WebSiteAddresses => [.. webSiteAddresses];

    public IReadOnlyList<PersonOrganizationBrigde> OrganizationBrigdes => [.. organizationBrigdes];

    public void Add(EmailAddress value) => emailAddresses.Add(value);

    public void Remove(EmailAddress value) => emailAddresses.Remove(value);

    public void Add(PhoneNumber value) => phoneNumbers.Add(value);

    public void Remove(PhoneNumber value) => phoneNumbers.Remove(value);

    public void Add(PostalAddress value) => postalAddresses.Add(value);

    public void Remove(PostalAddress value) => postalAddresses.Remove(value);

    public void Add(WebSiteAddress value) => webSiteAddresses.Add(value);

    public void Remove(WebSiteAddress value) => webSiteAddresses.Remove(value);

    public void LinkOrganizationById(OrganizationId organizationId, bool IsRepresentative) => organizationBrigdes.Add(new PersonOrganizationBrigde(Id, organizationId, IsRepresentative));

    public void UnlinkOrganizationById(OrganizationId organizationId) => organizationBrigdes.Remove(organizationBrigdes.First(bridge => bridge.LinkedId == organizationId));
}
