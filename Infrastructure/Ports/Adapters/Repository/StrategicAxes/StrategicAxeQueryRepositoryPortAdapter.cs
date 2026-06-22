using Microsoft.EntityFrameworkCore;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicAxes.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicAxeAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicAxeAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Persistence.EF;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Persistence.EF.Repositories.Abstractions;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Ports.Adapters.Repository.StrategicAxes;

internal sealed class StrategicAxeQueryRepositoryPortAdapter : AbstractEntityQueryRepositoryPortAdapter<StrategicAxe, StrategicAxeId, int>, IStrategicAxeQueryRepositoryPort
{
    public StrategicAxeQueryRepositoryPortAdapter(DefaultDbContext dbContext) : base(dbContext)
    {
    }

    protected override IQueryable<StrategicAxe> GetQueryableDbSet()
    {
        return base.GetQueryableDbSet().Include(entity => entity.Coordinator).ThenInclude(entity => entity!.Image);
    }
}