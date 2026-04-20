using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Common.Aggregate.Abstractions;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Common.Aggregate.Intefaces;

public interface IBridge<TMainEntity, TMainEntityId, TMainEntityIdValue, TLinkedEntity, TLinkedEntityId, TLinkedEntityIdValue>
    where TMainEntity : AbstractEntity<TMainEntityId, TMainEntityIdValue>
    where TMainEntityId : struct, IId<TMainEntityIdValue>
    where TLinkedEntity : AbstractEntity<TLinkedEntityId, TLinkedEntityIdValue>
    where TLinkedEntityId : struct, IId<TLinkedEntityIdValue>
{
    TMainEntityId MainId { get; set; }
    TMainEntity? Main { get; set; }

    TLinkedEntityId LinkedId { get; set; }
    TLinkedEntity? Linked { get; set; }
}