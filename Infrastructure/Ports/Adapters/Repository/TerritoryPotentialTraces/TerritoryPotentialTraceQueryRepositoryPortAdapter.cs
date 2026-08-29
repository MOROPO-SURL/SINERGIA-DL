using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.TerritoryPotentialTraces.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TraceAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TraceAggregate.Values;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Persistence.EF;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Persistence.EF.Repositories.Abstractions;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Ports.Adapters.Repository.TerritoryPotentialTraces;

internal sealed class TerritoryPotentialTraceQueryRepositoryPortAdapter : AbstractEntityQueryRepositoryPortAdapter<TerritoryPotentialTrace, TraceId, long>, ITerritoryPotentialTraceQueryRepositoryPort
{
    public TerritoryPotentialTraceQueryRepositoryPortAdapter(DefaultDbContext dbContext) : base(dbContext)
    {
    }
}