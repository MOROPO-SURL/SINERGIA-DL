using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.OrganizationAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.OrganizationAggregate.Values;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.PersonAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.PersonAggregate.Values;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Common.Aggregate.Intefaces;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Bridges;

public class PersonOrganizationBrigde : IBridge<Person, PersonId, Guid, Organization, OrganizationId, Guid>
{
    private PersonOrganizationBrigde() { }

    public PersonOrganizationBrigde(PersonId mainId, OrganizationId linkedId, bool isRepresentative, Person? main = null, Organization? linked = null)
    {
        MainId = mainId;
        LinkedId = linkedId;
        Main = main;
        Linked = linked;
        IsRepresentative = isRepresentative;
    }

    public PersonId MainId { get; set; }
    public Person? Main { get; set; }

    public OrganizationId LinkedId { get; set; }
    public Organization? Linked { get; set; }

    public bool IsRepresentative { get; set; }
}