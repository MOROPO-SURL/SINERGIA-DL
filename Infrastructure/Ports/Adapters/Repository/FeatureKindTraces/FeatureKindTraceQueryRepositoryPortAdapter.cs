using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.FeatureKindTraces.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TraceAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TraceAggregate.Values;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Persistence.EF;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Persistence.EF.Repositories.Abstractions;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Ports.Adapters.Repository.FeatureKindTraces;

internal sealed class FeatureKindTraceQueryRepositoryPortAdapter : AbstractEntityQueryRepositoryPortAdapter<FeatureKindTrace, TraceId, long>, IFeatureKindTraceQueryRepositoryPort
{
    public FeatureKindTraceQueryRepositoryPortAdapter(DefaultDbContext dbContext) : base(dbContext)
    {
    }
}