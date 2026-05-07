using Microsoft.EntityFrameworkCore;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicLines.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicAxeAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicLineAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicLineAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Persistence.EF;
using System.Linq.Expressions;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Ports.Adapters.Repository.StrategicLines;

internal sealed class StrategicLineQueryRepositoryPortAdapter : IStrategicLineQueryRepositoryPort
{
    private readonly IQueryable<StrategicLine> baseQueryableDbSet;

    public StrategicLineQueryRepositoryPortAdapter(DefaultDbContext dbContext)
    {
        baseQueryableDbSet = dbContext.Set<StrategicLine>()
            .AsNoTracking()
            .AsSplitQuery()
            .Include(entity => entity.StrategicAxe)
            .Include(entity => entity.Coordinator).ThenInclude(entity => entity!.Image);
    }

    private IQueryable<StrategicLine> GetQueryableDbSet() => baseQueryableDbSet;

    public Task<int> CountAsync()
    {
        return baseQueryableDbSet.CountAsync();
    }

    public Task<int> CountAsync(Expression<Func<StrategicLine, bool>> criteria)
    {
        return baseQueryableDbSet.Where(criteria).CountAsync();
    }

    public Task<StrategicLine?> FindOneByAsync(Expression<Func<StrategicLine, bool>> criteria)
    {
        return GetQueryableDbSet().Where(criteria).FirstOrDefaultAsync();
    }

    public IQueryable<StrategicLine> GetAllQueryable()
    {
        return GetQueryableDbSet();
    }

    public Task<StrategicLine> GetAsync(StrategicLineId firstId, StrategicAxeId secoundId)
    {
        return GetQueryableDbSet().Where(entity => entity.FirstId.Equals(firstId) && entity.SecoundId.Equals(secoundId)).FirstAsync();
    }

    public IQueryable<StrategicLine> GetFindByQueryable(Expression<Func<StrategicLine, bool>> criteria)
    {
        return GetQueryableDbSet().Where(criteria);
    }

    public IQueryable<StrategicLine> GetPageQueryable(int page, int limit, Expression<Func<StrategicLine, bool>>? criteria = null)
    {
        if (criteria != null)
        {
            return GetAllQueryable().Where(criteria).OrderBy(entity => entity.SecoundId).ThenBy(entity => entity.FirstId).Skip((page - 1) * limit).Take(limit);
        }

        return GetQueryableDbSet().OrderBy(entity => entity.SecoundId).ThenBy(entity => entity.FirstId).Skip((page - 1) * limit).Take(limit);
    }
}