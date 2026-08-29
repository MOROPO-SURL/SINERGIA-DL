using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.InterestAreaTraces.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TraceAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TraceAggregate.Values;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Persistence.EF;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Persistence.EF.Repositories.Abstractions;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Ports.Adapters.Repository.InterestAreaTraces;

internal sealed class InterestAreaTraceQueryRepositoryPortAdapter : AbstractEntityQueryRepositoryPortAdapter<InterestAreaTrace, TraceId, long>, IInterestAreaTraceQueryRepositoryPort
{
    public InterestAreaTraceQueryRepositoryPortAdapter(DefaultDbContext dbContext) : base(dbContext)
    {
    }
}
