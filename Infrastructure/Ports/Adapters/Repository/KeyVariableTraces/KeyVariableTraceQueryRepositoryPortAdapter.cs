using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.KeyVariableTraces.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TraceAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TraceAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Persistence.EF;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Persistence.EF.Repositories.Abstractions;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Ports.Adapters.Repository.KeyVariableTraces;

internal class KeyVariableTraceQueryRepositoryPortAdapter : AbstractEntityQueryRepositoryPortAdapter<KeyVariableTrace, TraceId, long>, IKeyVariableTraceQueryRepositoryPort
{
    public KeyVariableTraceQueryRepositoryPortAdapter(DefaultDbContext dbContext) : base(dbContext)
    {
    }
}
