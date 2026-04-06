using MOROPO.GEDET.CAM.Domain.Aggretates.OrganizationAggregate;
using MOROPO.GEDET.CAM.Domain.Aggretates.OrganizationAggregate.Values;
using MOROPO.GEDET.CAM.Domain.Aggretates.PersonAggregate;
using MOROPO.GEDET.CAM.Domain.Aggretates.PersonAggregate.Values;
using MOROPO.GEDET.CAM.Domain.Common.Aggregate.Intefaces;

namespace MOROPO.GEDET.CAM.Domain.Bridges;

public class PersonOrganizationBrigde : IBridge<Person, PersonId, Guid, Organization, OrganizationId, Guid>
{
    private PersonOrganizationBrigde() { }

    public PersonOrganizationBrigde(PersonId mainId, OrganizationId linkedId)
    {
        MainId = mainId;
        LinkedId = linkedId;
    }

    public PersonId MainId { get; set; }
    public Person? Main { get; set; }

    public OrganizationId LinkedId { get; set; }
    public Organization? Linked { get; set; }
}