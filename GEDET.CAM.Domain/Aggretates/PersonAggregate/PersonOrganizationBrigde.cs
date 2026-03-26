namespace MOROPO.GEDET.CAM.Domain.Aggretates.PersonAggregate;

public class PersonOrganizationBrigde : Common.Aggregate.Contract.IBridge<Person, PersonId, OrganizationAggregate.Organization, OrganizationAggregate.OrganizationId>
{
    public PersonOrganizationBrigde(PersonId mainId, Person main, OrganizationAggregate.OrganizationId linkedId, OrganizationAggregate.Organization linked)
    {
        MainId = mainId;
        Main = main;
        LinkedId = linkedId;
        Linked = linked;
    }

    public PersonId MainId { get ; set ; }
    public Person Main { get ; set ; }

    public OrganizationAggregate.OrganizationId LinkedId { get ; set ; }
    public OrganizationAggregate.Organization Linked { get ; set ; }
}
