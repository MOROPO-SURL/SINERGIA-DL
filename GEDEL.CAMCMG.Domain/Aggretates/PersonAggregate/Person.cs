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
    private Person() : base(new PersonId(default)) { }

    public Person(PersonId id, int priority, bool isEnabled, bool isArchived, string name, Sex sex, CivilStatus civilStatus, List<EmailAddress> emailAddresses, List<PhoneNumber> phoneNumbers, List<PostalAddress> postalAddresses, List<WebSiteContact> webSites, string? lastName = null, string? alias = null, DateTime? bornDate = null, string? about = null, Image? image = null, ImageId? imageId = null) : base(id)
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
        EmailAddresses = emailAddresses;
        PhoneNumbers = phoneNumbers;
        PostalAddresses = postalAddresses;
        WebSites = webSites;
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

    public List<EmailAddress> EmailAddresses { get; set; } = null!;

    public List<PhoneNumber> PhoneNumbers { get; set; } = null!;

    public List<PostalAddress> PostalAddresses { get; set; } = null!;

    public List<WebSiteContact> WebSites { get; set; } = null!;

    public List<PersonOrganizationBrigde> OrganizationBrigde { get; set; } = [];
}
