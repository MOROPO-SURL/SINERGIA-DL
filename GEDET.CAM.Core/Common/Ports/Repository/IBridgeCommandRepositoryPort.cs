using MOROPO.GEDET.CAM.Domain.Common.Aggregate.Abstractions;
using MOROPO.GEDET.CAM.Domain.Common.Aggregate.Intefaces;

namespace MOROPO.GEDET.CAM.Core.Common.Ports.Repository;

public interface IBridgeCommandRepositoryPort<TBridge, TMainEntity, TMainEntityId, TLinkedEntity, TLinkedEntityId>
    where TBridge : class, IBridge<TMainEntity, TMainEntityId, TLinkedEntity, TLinkedEntityId>
    where TMainEntity : AbstractEntity<TMainEntityId>
    where TLinkedEntity : AbstractEntity<TLinkedEntityId>
{
    TBridge Add(TBridge bridge, string author, bool commit = true);

    TBridge Update(TBridge bridge, string author, bool commit = true);

    void Delete(TBridge bridge, string author, bool commit = true);
}
