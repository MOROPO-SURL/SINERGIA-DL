using MOROPO.GEDET.CAM.Domain.Common.Aggregate.Abstractions;
using MOROPO.GEDET.CAM.Domain.Common.Aggregate.Intefaces;

namespace MOROPO.GEDET.CAM.Core.Common.Ports.Repository;

public interface IBridgeCommandRepositoryPort<TBridge, TMainEntity, TMainEntityId, TLinkedEntity, TLinkedEntityId>
    where TBridge : class, IBridge<TMainEntity, TMainEntityId, TLinkedEntity, TLinkedEntityId>
    where TMainEntity : AbstractEntity<TMainEntityId>
    where TLinkedEntity : AbstractEntity<TLinkedEntityId>
{
    Task<TBridge> AddAsync(TBridge bridge, string author, bool commit = true);

    Task<TBridge> UpdateAsync(TBridge bridge, string author, bool commit = true);

    Task DeleteAsync(TBridge bridge, string author, bool commit = true);
}