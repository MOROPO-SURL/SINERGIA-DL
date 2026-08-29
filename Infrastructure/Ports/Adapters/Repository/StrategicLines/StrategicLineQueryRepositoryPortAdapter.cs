using Microsoft.EntityFrameworkCore;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicLines.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.StrategicLineAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.StrategicLineAggregate.Values;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Persistence.EF;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Persistence.EF.Repositories.Abstractions;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Ports.Adapters.Repository.StrategicLines;

internal sealed class StrategicLineQueryRepositoryPortAdapter : AbstractEntityQueryRepositoryPortAdapter<StrategicLine, StrategicLineId, Guid>, IStrategicLineQueryRepositoryPort
{
    public StrategicLineQueryRepositoryPortAdapter(DefaultDbContext dbContext) : base(dbContext)
    {
    }

    protected override IQueryable<StrategicLine> GetQueryableDbSet()
    {
        return base.GetQueryableDbSet()
            .AsSplitQuery()
            .Include(entity => entity.Axe)
            .Include(entity => entity.Coordinator).ThenInclude(entity => entity!.Image)
            .Include(entity => entity.PublicPolicyBridges).ThenInclude(bridge => bridge.Linked)
            .Include(entity => entity.MacroprogramBridges).ThenInclude(bridge => bridge.Linked)
            .Include(entity => entity.OrganizationBridges).ThenInclude(bridge => bridge.Linked).ThenInclude(entity => entity!.Kind)
            .Include(entity => entity.OrganizationBridges).ThenInclude(bridge => bridge.Linked).ThenInclude(entity => entity!.Image);
    }
}