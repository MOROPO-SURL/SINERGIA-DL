using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.KeyVariableTraces.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TraceAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TraceAggregate.Values;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Persistence.EF;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Persistence.EF.Repositories.Abstractions;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Ports.Adapters.Repository.KeyVariableTraces;

internal sealed class KeyVariableTraceQueryRepositoryPortAdapter : AbstractEntityQueryRepositoryPortAdapter<KeyVariableTrace, TraceId, long>, IKeyVariableTraceQueryRepositoryPort
{
    public KeyVariableTraceQueryRepositoryPortAdapter(DefaultDbContext dbContext) : base(dbContext)
    {
    }
}
