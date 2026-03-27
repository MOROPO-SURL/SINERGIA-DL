using MOROPO.GEDET.CAM.Domain.Common.Aggregate.Intefaces;
using System.Linq.Expressions;

namespace MOROPO.GEDET.CAM.Core.Common.Ports.Repository;

public interface IEntityQueryRepositoryPort<TEntity, TId> where TEntity : class, IEntity<TId>
{
    IQueryable<TEntity> GetAllQueryable();

    int Count();

    int Count(Expression<Func<TEntity, bool>> criteria);

    TEntity Get(TId id);

    TEntity? FindOneBy(Expression<Func<TEntity, bool>> criteria);

    TEntity[] FindBy(Expression<Func<TEntity, bool>> criteria);

    TEntity[] GetPage(int page, int limit);
}
