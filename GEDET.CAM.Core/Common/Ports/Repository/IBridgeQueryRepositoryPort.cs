using MOROPO.GEDET.CAM.Domain.Common.Aggregate.Abstractions;
using MOROPO.GEDET.CAM.Domain.Common.Aggregate.Intefaces;
using System.Linq.Expressions;

namespace MOROPO.GEDET.CAM.Core.Common.Ports.Repository;

public interface IBridgeQueryRepositoryPort<TBridge, TMainEntity, TMainEntityId, TMainEntityIdValue, TLinkedEntity, TLinkedEntityId, TLinkedEntityIdValue>
    where TBridge : class, IBridge<TMainEntity, TMainEntityId, TMainEntityIdValue, TLinkedEntity, TLinkedEntityId, TLinkedEntityIdValue>
    where TMainEntity : AbstractEntity<TMainEntityId, TMainEntityIdValue>
    where TMainEntityId : struct, IId<TMainEntityIdValue>
    where TLinkedEntity : AbstractEntity<TLinkedEntityId, TLinkedEntityIdValue>
    where TLinkedEntityId : struct, IId<TLinkedEntityIdValue>
{
    Task<TBridge> GetAsync(TMainEntityId mainId, TLinkedEntityId linkedId);

    Task<TBridge> FindOneByAsync(Expression<Func<TBridge, bool>> criteria);

    IQueryable<TBridge> GetFindByQueryable(Expression<Func<TBridge, bool>> criteria);

    IQueryable<TBridge> GetAllQueryable();

    IQueryable<TBridge> GetPageQueryable(int page, int limit);

    Task<int> CountAsync();

    Task<int> CountAsync(Expression<Func<TBridge, bool>> criteria);
}