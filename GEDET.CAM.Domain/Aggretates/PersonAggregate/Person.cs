using MOROPO.GEDET.CAM.Domain.Aggretates.ImageAggregate;
using MOROPO.GEDET.CAM.Domain.Aggretates.ImageAggregate.Values;
using MOROPO.GEDET.CAM.Domain.Aggretates.PersonAggregate.Enumerations;
using MOROPO.GEDET.CAM.Domain.Aggretates.PersonAggregate.Values;
using MOROPO.GEDET.CAM.Domain.Bridges;
using MOROPO.GEDET.CAM.Domain.Common.Aggregate;
using MOROPO.GEDET.CAM.Domain.Common.Aggregate.Abstractions;
using MOROPO.GEDET.CAM.Domain.Common.Aggregate.Intefaces;

namespace MOROPO.GEDET.CAM.Domain.Aggretates.PersonAggregate;

public class Person : AbstractAuditableEntity<PersonId, Guid>, IAggregateRoot<PersonId, Guid>, INamedEntity<PersonId, Guid>, IArchivableEntity<PersonId, Guid>, IEnableableEntity<PersonId, Guid>, IPriorizableEntity<PersonId, Guid>
{
    public Person(PersonId id, string? alias, DateTime? bornDate, string? about, int priority, bool enabled, bool isArchived, string name, string lastName, Sex sex, CivilStatus civilStatus, Image image, ImageId? imageId, List<EmailAddress> emailAddresses, List<PhoneNumber> phoneNumbers, List<PostalAddress> postalAddresses, List<WebSiteContact> webSites, PersonOrganizationBrigde[] organizationBrigdes): base(id)
    {
        Alias = alias;
        BornDate = bornDate;
        About = about;
        Priority = priority;
        IsEnabled = enabled;
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
    
    public bool IsEnabled { get ; set ; }
    
    public bool IsArchived { get ; set ; }
    
    public string Name { get ; set ; }

    public string LastName { get; set; }

    public Sex Sex { get; set; }

    public CivilStatus CivilStatus { get; set; }

    public Image? Image { get; set; }
    public ImageId? ImageId { get; set; }

    public List<EmailAddress> EmailAddresses { get; set; }

    public List<PhoneNumber> PhoneNumbers { get; set; }

    public List<PostalAddress> PostalAddresses { get; set; }

    public List<WebSiteContact> WebSites { get; set; }

    public List<PersonOrganizationBrigde> OrganizationBrigde { get; set; }
}