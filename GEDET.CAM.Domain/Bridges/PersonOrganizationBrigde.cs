using MOROPO.GEDET.CAM.Domain.Aggretates.OrganizationAggregate;
using MOROPO.GEDET.CAM.Domain.Aggretates.OrganizationAggregate.Values;
using MOROPO.GEDET.CAM.Domain.Aggretates.PersonAggregate;
using MOROPO.GEDET.CAM.Domain.Aggretates.PersonAggregate.Values;
using MOROPO.GEDET.CAM.Domain.Common.Aggregate.Intefaces;

namespace MOROPO.GEDET.CAM.Domain.Bridges;

public class PersonOrganizationBrigde : IBridge<Person, PersonId, Organization, OrganizationId>
{
    private PersonOrganizationBrigde() { }

    public PersonOrganizationBrigde(PersonId mainId, Person main, OrganizationId linkedId, Organization linked)
    {
        MainId = mainId;
        Main = main;
        LinkedId = linkedId;
        Linked = linked;
    }

    public PersonId MainId { get; set; }
    public Person Main { get; set; } = null!;

    public OrganizationId LinkedId { get; set; }
    public Organization Linked { get; set; } = null!;
}
