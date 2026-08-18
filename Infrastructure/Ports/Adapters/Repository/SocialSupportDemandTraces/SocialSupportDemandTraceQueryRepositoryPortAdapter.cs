using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.SocialSupportDemandTraces.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TraceAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TraceAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Persistence.EF;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Persistence.EF.Repositories.Abstractions;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Ports.Adapters.Repository.SocialSupportDemandTraces;

internal sealed class SocialSupportDemandTraceQueryRepositoryPortAdapter : AbstractEntityQueryRepositoryPortAdapter<SocialSupportDemandTrace, TraceId, long>, ISocialSupportDemandTraceQueryRepositoryPort
{
    public SocialSupportDemandTraceQueryRepositoryPortAdapter(DefaultDbContext dbContext) : base(dbContext)
    {
    }
}