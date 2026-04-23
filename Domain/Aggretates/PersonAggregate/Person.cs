using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.ImageAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.ImageAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.PersonAggregate.Enumerations;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.PersonAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Bridges;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Common.Aggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Common.Aggregate.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Common.Aggregate.Intefaces;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.PersonAggregate;

public class Person : AbstractAuditableEntity<PersonId, Guid>, IAggregateRoot<PersonId, Guid>, INamedEntity<PersonId, Guid>, IArchivableEntity<PersonId, Guid>, IEnableableEntity<PersonId, Guid>, IPriorizableEntity<PersonId, Guid>
{
    private readonly List<EmailAddress> emailAddresses = [];
    private readonly List<PhoneNumber> phoneNumbers = [];
    private readonly List<PostalAddress> postalAddresses = [];
    private readonly List<WebSiteAddress> webSiteAddresses = [];

    private Person() : base(new PersonId(default)) { }

    public Person(PersonId id, int priority, bool isEnabled, bool isArchived, string name, Sex sex, CivilStatus civilStatus, EmailAddress[] emailAddresses, PhoneNumber[] phoneNumbers, PostalAddress[] postalAddresses, WebSiteAddress[] webSiteAddresses, string? lastName = null, string? alias = null, DateTime? bornDate = null, string? about = null, Image? image = null, ImageId? imageId = null) : base(id)
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
        Image = image;
        ImageId = imageId;

        this.emailAddresses = [.. emailAddresses];
        this.phoneNumbers = [.. phoneNumbers];
        this.postalAddresses = [.. postalAddresses];
        this.webSiteAddresses = [.. webSiteAddresses];
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

    public IReadOnlyList<EmailAddress> EmailAddresses => [.. emailAddresses];

    public IReadOnlyList<PhoneNumber> PhoneNumbers => [.. phoneNumbers];

    public IReadOnlyList<PostalAddress> PostalAddresses => [.. postalAddresses];

    public IReadOnlyList<WebSiteAddress> WebSiteAddresses => [.. webSiteAddresses];

    public List<PersonOrganizationBrigde> OrganizationBrigde { get; set; } = [];

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
