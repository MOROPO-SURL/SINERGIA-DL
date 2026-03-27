using MOROPO.GEDET.CAM.Domain.Common.Aggregate.Abstractions;
using MOROPO.GEDET.CAM.Domain.Common.Aggregate.Intefaces;
using System.Linq.Expressions;

namespace MOROPO.GEDET.CAM.Core.Common.Ports.Repository;

public interface IBridgeQueryRepositoryPort<TBridge, TMainEntity, TMainEntityId, TLinkedEntity, TLinkedEntityId>
    where TBridge : class, IBridge<TMainEntity, TMainEntityId, TLinkedEntity, TLinkedEntityId>
    where TMainEntity : AbstractEntity<TMainEntityId>
    where TLinkedEntity : AbstractEntity<TLinkedEntityId>
{
    TBridge Get(TMainEntityId mainId, TLinkedEntityId linkedId);

    TBridge FindOneBy(Expression<Func<TBridge, bool>> criteria);

    IQueryable<TBridge> FindBy(Expression<Func<TBridge, bool>> criteria);

    IQueryable<TBridge> GetAll();

    TBridge[] GetPage(int page, int limit);

    int Count();

    int Count(Expression<Func<TBridge, bool>> criteria);
}
