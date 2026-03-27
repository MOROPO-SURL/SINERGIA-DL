using MOROPO.GEDET.CAM.Domain.Common.Aggregate.Abstractions;

namespace MOROPO.GEDET.CAM.Domain.Common.Aggregate.Intefaces;

public interface IBridge<TMainEntity, TMainEntityId, TLinkedEntity, TLinkedEntityId>
    where TMainEntity : AbstractEntity<TMainEntityId>
    where TLinkedEntity : AbstractEntity<TLinkedEntityId>
{
    TMainEntityId MainId { get; set; }
    TMainEntity Main { get; set; }

    TLinkedEntityId LinkedId { get; set; }
    TLinkedEntity Linked { get; set; }

}
