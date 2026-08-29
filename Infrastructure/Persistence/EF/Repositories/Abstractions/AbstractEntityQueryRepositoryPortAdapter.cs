using Microsoft.EntityFrameworkCore;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Common.Aggregate.Intefaces;
using System.Linq.Expressions;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Persistence.EF.Repositories.Abstractions;

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

    public IQueryable<TEntity> GetAllQueryable(Expression<Func<TEntity, object>>? orderExpression = null, bool isOrderDesending = false)
    {
        if (orderExpression != null)
        {
            if (isOrderDesending)
            {
                return GetQueryableDbSet().OrderByDescending(orderExpression);
            }
            else
            {
                return GetQueryableDbSet().OrderBy(orderExpression);
            }
        }

        return GetQueryableDbSet();
    }

    public IQueryable<TEntity> GetFindByQueryable(Expression<Func<TEntity, bool>> criteria, Expression<Func<TEntity, object>>? orderExpression = null, bool isOrderDesending = false)
    {
        if (orderExpression != null)
        {
            if (isOrderDesending)
            {
                return GetQueryableDbSet().Where(criteria).OrderByDescending(orderExpression);
            }
            else
            {
                return GetQueryableDbSet().Where(criteria).OrderBy(orderExpression);
            }
        }

        return GetQueryableDbSet().Where(criteria);
    }

    public IQueryable<TEntity> GetPageQueryable(int page, int limit, Expression<Func<TEntity, object>> orderExpression, bool isOrderDescending = false, Expression<Func<TEntity, bool>>? criteria = null)
    {
        if (criteria != null)
        {
            if (isOrderDescending)
            {
                return GetQueryableDbSet().Where(criteria).OrderByDescending(orderExpression).Skip((page - 1) * limit).Take(limit);
            }

            return GetAllQueryable().Where(criteria).OrderBy(orderExpression).Skip((page - 1) * limit).Take(limit);
        }

        if (isOrderDescending)
        {
            return GetQueryableDbSet().OrderByDescending(orderExpression).Skip((page - 1) * limit).Take(limit);
        }

        return GetQueryableDbSet().OrderBy(orderExpression).Skip((page - 1) * limit).Take(limit);
    }
}