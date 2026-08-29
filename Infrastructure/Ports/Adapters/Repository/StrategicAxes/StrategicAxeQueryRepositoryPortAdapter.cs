using Microsoft.EntityFrameworkCore;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicAxes.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.StrategicAxeAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.StrategicAxeAggregate.Values;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Persistence.EF;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Persistence.EF.Repositories.Abstractions;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Ports.Adapters.Repository.StrategicAxes;

internal sealed class StrategicAxeQueryRepositoryPortAdapter : AbstractEntityQueryRepositoryPortAdapter<StrategicAxe, StrategicAxeId, int>, IStrategicAxeQueryRepositoryPort
{
    public StrategicAxeQueryRepositoryPortAdapter(DefaultDbContext dbContext) : base(dbContext)
    {
    }

    protected override IQueryable<StrategicAxe> GetQueryableDbSet()
    {
        return base.GetQueryableDbSet()
            .Include(entity => entity.MacroprogramBridges).ThenInclude(bridge => bridge.Linked)
            .Include(entity => entity.Coordinator).ThenInclude(entity => entity!.Image);
    }
}