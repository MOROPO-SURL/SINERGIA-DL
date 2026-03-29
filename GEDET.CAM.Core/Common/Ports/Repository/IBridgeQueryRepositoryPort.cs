using MOROPO.GEDET.CAM.Domain.Common.Aggregate.Abstractions;
using MOROPO.GEDET.CAM.Domain.Common.Aggregate.Intefaces;
using System.Linq.Expressions;

namespace MOROPO.GEDET.CAM.Core.Common.Ports.Repository;

public interface IBridgeQueryRepositoryPort<TBridge, TMainEntity, TMainEntityId, TLinkedEntity, TLinkedEntityId>
    where TBridge : class, IBridge<TMainEntity, TMainEntityId, TLinkedEntity, TLinkedEntityId>
    where TMainEntity : AbstractEntity<TMainEntityId>
    where TLinkedEntity : AbstractEntity<TLinkedEntityId>
{
    Task<TBridge> GetAsync(TMainEntityId mainId, TLinkedEntityId linkedId);

    Task<TBridge> FindOneByAsync(Expression<Func<TBridge, bool>> criteria);

    IQueryable<TBridge> GetFindByQueryable(Expression<Func<TBridge, bool>> criteria);

    IQueryable<TBridge> GetAllQueryable();

    IQueryable<TBridge> GetPageQueryable(int page, int limit);

    Task<int> CountAsync();

    Task<int> CountAsync(Expression<Func<TBridge, bool>> criteria);
}
