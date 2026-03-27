using Microsoft.EntityFrameworkCore;
using MOROPO.GEDET.CAM.Core.Common.Ports.Repository;
using MOROPO.GEDET.CAM.Domain.Common.Aggregate.Intefaces;
using System.Linq.Expressions;

namespace MOROPO.GEDET.CAM.Infrastructure.Persistence.EF.Repositories.Abstractions;

internal abstract class AbstractQueryRepositoryAdapter<TEntity, TId> : IEntityQueryRepositoryPort<TEntity, TId> where TEntity : class, IEntity<TId> where TId : struct
{
    protected readonly IQueryable<TEntity> baseQueryableDbSet;

    protected AbstractQueryRepositoryAdapter(DefaultDbContext dbContext)
    {
        baseQueryableDbSet = dbContext.Set<TEntity>().AsNoTracking();
    }

    protected virtual Func<TEntity, bool> GetKeySelector(TId key)
    {
        return e => e.Id.Equals(key);
    }

    protected virtual IQueryable<TEntity> GetQueryableDbSet() => baseQueryableDbSet;

    public IQueryable<TEntity> GetAllQueryable()
    {
        return GetQueryableDbSet();
    }

    public int Count()
    {
        return baseQueryableDbSet.Count();
    }

    public int Count(Expression<Func<TEntity, bool>> criteria)
    {
        return baseQueryableDbSet.Where(criteria).Count();
    }

    public TEntity Get(TId id)
    {
        return GetQueryableDbSet().Where(GetKeySelector(id)).First();
    }

    public TEntity? FindOneBy(Expression<Func<TEntity, bool>> criteria)
    {
        return GetQueryableDbSet().Where(criteria).FirstOrDefault();
    }

    public TEntity[] FindBy(Expression<Func<TEntity, bool>> criteria)
    {
        return [.. GetQueryableDbSet().Where(criteria)];
    }

    public TEntity[] GetPage(int page, int limit)
    {
        return [.. GetQueryableDbSet().Skip(page * limit).Take(limit)];
    }
}
