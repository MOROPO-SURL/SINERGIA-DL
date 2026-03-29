using MOROPO.GEDET.CAM.Domain.Common.Aggregate.Intefaces;
using System.Linq.Expressions;

namespace MOROPO.GEDET.CAM.Core.Common.Ports.Repository;

public interface IEntityQueryRepositoryPort<TEntity, TId> where TEntity : class, IEntity<TId>
{
    Task<int> CountAsync();

    Task<int> CountAsync(Expression<Func<TEntity, bool>> criteria);

    Task<TEntity> GetAsync(TId id);

    Task<TEntity?> FindOneByAsync(Expression<Func<TEntity, bool>> criteria);

    IQueryable<TEntity> GetAllQueryable();

    IQueryable<TEntity> GetFindByQueryable(Expression<Func<TEntity, bool>> criteria);

    IQueryable<TEntity> GetPageQueryable(int page, int limit);
}
