using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Common.Aggregate.Intefaces;
using System.Linq.Expressions;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.Ports.Repository;

public interface IEntityQueryRepositoryPort<TEntity, TId, TIdValue>
    where TEntity : class, IEntity<TId, TIdValue>
    where TId : struct, IId<TIdValue>
{
    Task<int> CountAsync();

    Task<int> CountAsync(Expression<Func<TEntity, bool>> criteria);

    Task<TEntity> GetAsync(TId id);

    Task<TEntity?> FindOneByAsync(Expression<Func<TEntity, bool>> criteria);

    IQueryable<TEntity> GetAllQueryable();

    IQueryable<TEntity> GetFindByQueryable(Expression<Func<TEntity, bool>> criteria);

    IQueryable<TEntity> GetPageQueryable(int page, int limit, Expression<Func<TEntity, object>> orderExpression, bool isOrderDesending = false, Expression<Func<TEntity, bool>>? criteria = null);
}