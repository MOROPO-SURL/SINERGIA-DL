using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.FeatureTraces.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TraceAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TraceAggregate.Values;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Persistence.EF;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Persistence.EF.Repositories.Abstractions;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Ports.Adapters.Repository.FeatureTraces;

internal sealed class FeatureTraceQueryRepositoryPortAdapter : AbstractEntityQueryRepositoryPortAdapter<FeatureTrace, TraceId, long>, IFeatureTraceQueryRepositoryPort
{
    public FeatureTraceQueryRepositoryPortAdapter(DefaultDbContext dbContext) : base(dbContext)
    {
    }
}
