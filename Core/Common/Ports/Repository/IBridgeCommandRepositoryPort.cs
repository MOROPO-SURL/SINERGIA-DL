using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Common.Aggregate.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Common.Aggregate.Intefaces;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.Ports.Repository;

public interface IBridgeCommandRepositoryPort<TBridge, TMainEntity, TMainEntityId, TMainEntityIdValue, TLinkedEntity, TLinkedEntityId, TLinkedEntityIdValue>
    where TBridge : class, IBridge<TMainEntity, TMainEntityId, TMainEntityIdValue, TLinkedEntity, TLinkedEntityId, TLinkedEntityIdValue>
    where TMainEntity : AbstractEntity<TMainEntityId, TMainEntityIdValue>
    where TMainEntityId : struct, IId<TMainEntityIdValue>
    where TLinkedEntity : AbstractEntity<TLinkedEntityId, TLinkedEntityIdValue>
    where TLinkedEntityId : struct, IId<TLinkedEntityIdValue>
{
    Task<TBridge> AddAsync(TBridge bridge, bool commit = true);

    Task<TBridge> UpdateAsync(TBridge bridge, bool commit = true);

    Task DeleteAsync(TBridge bridge, bool commit = true);
}