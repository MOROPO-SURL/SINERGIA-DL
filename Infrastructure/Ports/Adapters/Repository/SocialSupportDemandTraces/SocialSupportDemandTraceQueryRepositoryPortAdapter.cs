using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.SocialSupportDemandTraces.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TraceAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TraceAggregate.Values;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Persistence.EF;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Persistence.EF.Repositories.Abstractions;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Ports.Adapters.Repository.SocialSupportDemandTraces;

internal sealed class SocialSupportDemandTraceQueryRepositoryPortAdapter : AbstractEntityQueryRepositoryPortAdapter<SocialSupportDemandTrace, TraceId, long>, ISocialSupportDemandTraceQueryRepositoryPort
{
    public SocialSupportDemandTraceQueryRepositoryPortAdapter(DefaultDbContext dbContext) : base(dbContext)
    {
    }
}