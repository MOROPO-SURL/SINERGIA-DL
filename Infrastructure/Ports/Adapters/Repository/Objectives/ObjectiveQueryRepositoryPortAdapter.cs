using Microsoft.EntityFrameworkCore;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Objectives.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.ObjectiveAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.ObjectiveAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Persistence.EF;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Persistence.EF.Repositories.Abstractions;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Ports.Adapters.Repository.Objectives;

internal sealed class ObjectiveQueryRepositoryPortAdapter : AbstractEntityQueryRepositoryPortAdapter<Objective, ObjectiveId, Guid>, IObjectiveQueryRepositoryPort
{
    public ObjectiveQueryRepositoryPortAdapter(DefaultDbContext dbContext) : base(dbContext)
    {
    }

    protected override IQueryable<Objective> GetQueryableDbSet()
    {
        return base.GetQueryableDbSet()
            .AsSplitQuery()
            // TODO Choise to use if required!!
            //.IgnoreAutoIncludes()
            .Include(entity => entity.Actions).ThenInclude(entity => entity.Indicators).ThenInclude(entity => entity.UnitMeasurement);
    }
}
