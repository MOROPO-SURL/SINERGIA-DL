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

    public IQueryable<TEntity> GetPageQueryable(int page, int limit)
    {
        return GetQueryableDbSet().Skip(page * limit).Take(limit);
    }
}
