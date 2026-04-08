using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.OrganizationAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.OrganizationAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.PersonAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.PersonAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Common.Aggregate.Intefaces;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Bridges;

public class PersonOrganizationBrigde : IBridge<Person, PersonId, Guid, Organization, OrganizationId, Guid>
{
    private PersonOrganizationBrigde() { }

    public PersonOrganizationBrigde(PersonId mainId, OrganizationId linkedId, Person? main = null, Organization? linked = null)
    {
        MainId = mainId;
        LinkedId = linkedId;
        Main = main;
        Linked = linked;
    }

    public PersonId MainId { get; set; }
    public Person? Main { get; set; }

    public OrganizationId LinkedId { get; set; }
    public Organization? Linked { get; set; }
}