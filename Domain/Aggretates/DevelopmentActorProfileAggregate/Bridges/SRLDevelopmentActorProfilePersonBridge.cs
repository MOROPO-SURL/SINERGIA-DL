using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.DevelopmentActorProfileAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.PersonAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.PersonAggregate;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.DevelopmentActorProfileAggregate.Bridges;

public sealed class SRLDevelopmentActorProfilePersonBridge
{
    private SRLDevelopmentActorProfilePersonBridge() { }

    public SRLDevelopmentActorProfilePersonBridge(DevelopmentActorProfileId mainId, PersonId linkedId, Person? linked = null)
    {
        MainId = mainId;
        LinkedId = linkedId;
        Linked = linked;
    }

    public DevelopmentActorProfileId MainId { get; set; }

    public PersonId LinkedId { get; set; }
    public Person? Linked { get; set; }
}
