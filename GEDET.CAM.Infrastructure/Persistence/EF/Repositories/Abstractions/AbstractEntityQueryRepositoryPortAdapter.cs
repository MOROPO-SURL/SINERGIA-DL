using Microsoft.EntityFrameworkCore;
using MOROPO.GEDET.CAM.Core.Common.Ports.Repository;
using MOROPO.GEDET.CAM.Domain.Common.Aggregate.Intefaces;
using System.Linq.Expressions;

namespace MOROPO.GEDET.CAM.Infrastructure.Persistence.EF.Repositories.Abstractions;

internal abstract class AbstractEntityQueryRepositoryPortAdapter<TEntity, TId, TIdValue> : IEntityQueryRepositoryPort<TEntity, TId, TIdValue> 
    where TEntity : class, IEntity<TId, TIdValue> 
    where TId : struct, IId<TIdValue>
{
    protected readonly IQueryable<TEntity> baseQueryableDbSet;

    protected AbstractEntityQueryRepositoryPortAdapter(DefaultDbContext dbContext)
    {
        baseQueryableDbSet = dbContext.Set<TEntity>().AsNoTracking();
    }

    protected virtual IQueryable<TEntity> GetQueryableDbSet() => baseQueryableDbSet;

    public Task<int> CountAsync()
    {
        return baseQueryableDbSet.CountAsync();
    }

    public Task<int> CountAsync(Expression<Func<TEntity, bool>> criteria)
    {
        return baseQueryableDbSet.Where(criteria).CountAsync();
    }

    public Task<TEntity> GetAsync(TId id)
    {
        return GetQueryableDbSet().Where(entity => entity.Id.Equals(id)).FirstAsync();
    }

    public Task<TEntity?> FindOneByAsync(Expression<Func<TEntity, bool>> criteria)
    {
        return GetQueryableDbSet().Where(criteria).FirstOrDefaultAsync();
    }

    public IQueryable<TEntity> GetAllQueryable()
    {
        return GetQueryableDbSet();
    }

    public IQueryable<TEntity> GetFindByQueryable(Expression<Func<TEntity, bool>> criteria)
    {
        return GetQueryableDbSet().Where(criteria);
    }

    public IQueryable<TEntity> GetPageQueryable(int page, int limit, Expression<Func<TEntity, bool>>? criteria = null)
    {
        if (criteria != null)
        {
            return GetAllQueryable().Where(criteria).Skip((page - 1) * limit).Take(limit);
        }

        return GetQueryableDbSet().Skip((page - 1) * limit).Take(limit);
    }
}