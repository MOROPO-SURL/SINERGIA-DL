using MOROPO.GEDET.CAM.Domain.Aggretates.ImageAggregate;
using MOROPO.GEDET.CAM.Domain.Aggretates.ImageAggregate.Values;
using MOROPO.GEDET.CAM.Domain.Aggretates.OrganizationAggregate.Values;
using MOROPO.GEDET.CAM.Domain.Aggretates.PersonAggregate.Enumerations;
using MOROPO.GEDET.CAM.Domain.Aggretates.PersonAggregate.Values;
using MOROPO.GEDET.CAM.Domain.Bridges;
using MOROPO.GEDET.CAM.Domain.Common.Aggregate;
using MOROPO.GEDET.CAM.Domain.Common.Aggregate.Abstractions;
using MOROPO.GEDET.CAM.Domain.Common.Aggregate.Intefaces;

namespace MOROPO.GEDET.CAM.Domain.Aggretates.PersonAggregate;

public class Person : AbstractAuditableEntity<PersonId>, IAggregateRoot<PersonId>, INamedEntity<PersonId>, IArchivableEntity<PersonId>, IEnableableEntity<PersonId>, IPriorizableEntity<PersonId>
{
    private Person() : base(new PersonId(default)) { }

    public Person(PersonId id, string? alias, DateTime? bornDate, string? about, int priority, bool enabled, bool isArchived, string name, string lastName, Sex sex, CivilStatus civilStatus, Image image, ImageId? imageId, List<EmailAddress> emailAddresses, List<PhoneNumber> phoneNumbers, List<PostalAddress> postalAddresses, List<WebSiteContact> webSites, PersonOrganizationBrigde[] organizationBrigdes): base(id)
    {
        Alias = alias;
        BornDate = bornDate;
        About = about;
        Priority = priority;
        Enabled = enabled;
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
        OrganizationBrigde = [.. organizationBrigdes];
    }

    public string? Alias { get; set; }

    public DateTime? BornDate { get; set; }

    public string? About { get; set; }

    public int Priority { get ; set ; }
    
    public bool Enabled { get ; set ; }
    
    public bool IsArchived { get ; set ; }
    
    public string Name { get ; set ; } = null!;

    public string LastName { get; set; } = null!;

    public Sex Sex { get; set; }

    public CivilStatus CivilStatus { get; set; }

    public Image? Image { get; set; }
    public ImageId? ImageId { get; set; }

    public List<EmailAddress> EmailAddresses { get; set; } = null!;

    public List<PhoneNumber> PhoneNumbers { get; set; } = null!;

    public List<PostalAddress> PostalAddresses { get; set; } = null!;

    public List<WebSiteContact> WebSites { get; set; } = null!;

    public List<PersonOrganizationBrigde> OrganizationBrigde { get; set; } = null!;
}
