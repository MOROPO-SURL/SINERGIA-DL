using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.InterestAreaTraces.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TraceAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TraceAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Persistence.EF;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Persistence.EF.Repositories.Abstractions;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Ports.Adapters.Repository.InterestAreaTraces;

internal sealed class InterestAreaTraceQueryRepositoryPortAdapter : AbstractEntityQueryRepositoryPortAdapter<InterestAreaTrace, TraceId, long>, IInterestAreaTraceQueryRepositoryPort
{
    public InterestAreaTraceQueryRepositoryPortAdapter(DefaultDbContext dbContext) : base(dbContext)
    {
    }
}
