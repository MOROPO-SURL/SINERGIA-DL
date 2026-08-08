using Microsoft.EntityFrameworkCore;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicPrograms.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicProgramAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicProgramAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Persistence.EF;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Persistence.EF.Repositories.Abstractions;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Ports.Adapters.Repository.StrategicPrograms;

internal sealed class StrategicProgramQueryRepositoryPortAdapter : AbstractEntityQueryRepositoryPortAdapter<StrategicProgram, StrategicProgramId, Guid>, IStrategicProgramQueryRepositoryPort
{
    public StrategicProgramQueryRepositoryPortAdapter(DefaultDbContext dbContext) : base(dbContext)
    {
    }

    protected override IQueryable<StrategicProgram> GetQueryableDbSet()
    {
        return base.GetQueryableDbSet()
            .AsSplitQuery()
            .IgnoreAutoIncludes()
            .Include(entity => entity.Impacts)
            .Include(entity => entity.SpecificObjectives)
            .Include(entity => entity.Line).ThenInclude(entity => entity!.Axe)
            .Include(entity => entity.Coordinator).ThenInclude(entity => entity!.Image)
            .Include(entity => entity.Actions).ThenInclude(entity => entity.Indicators).ThenInclude(entity => entity.UnitMeasurement)
            .Include(entity => entity.Actions).ThenInclude(entity => entity.Indicators).ThenInclude(entity => entity.Milestones)
            .Include(entity => entity.MacroprogramBridges).ThenInclude(bridge => bridge.Linked)
            .Include(entity => entity.OrganizationBridges).ThenInclude(bridge => bridge.Linked).ThenInclude(entity => entity!.Kind)
            .Include(entity => entity.OrganizationBridges).ThenInclude(bridge => bridge.Linked).ThenInclude(entity => entity!.Image);
    }
}