using Microsoft.EntityFrameworkCore;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Objectives.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.ObjectiveAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.ObjectiveAggregate.Values;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Persistence.EF;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Persistence.EF.Repositories.Abstractions;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Ports.Adapters.Repository.Objectives;

internal sealed class ObjectiveQueryRepositoryPortAdapter : AbstractEntityQueryRepositoryPortAdapter<Objective, ObjectiveId, Guid>, IObjectiveQueryRepositoryPort
{
    public ObjectiveQueryRepositoryPortAdapter(DefaultDbContext dbContext) : base(dbContext)
    {
    }

    protected override IQueryable<Objective> GetQueryableDbSet()
    {
        return base.GetQueryableDbSet()
            .AsSplitQuery()
            .IgnoreAutoIncludes()
            .Include(entity => entity.Challenges)
            .Include(entity => entity.Projections)
            .Include(entity => entity.Actions).ThenInclude(entity => entity.Indicators).ThenInclude(entity => entity.UnitMeasurement)
            .Include(entity => entity.Actions).ThenInclude(entity => entity.Indicators).ThenInclude(entity => entity.Milestones);
    }
}