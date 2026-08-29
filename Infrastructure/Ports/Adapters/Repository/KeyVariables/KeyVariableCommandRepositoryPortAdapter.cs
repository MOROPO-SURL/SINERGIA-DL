using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.KeyVariables.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.KeyVariableAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.KeyVariableAggregate.Values;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Persistence.EF;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Persistence.EF.Repositories.Abstractions;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Ports.Adapters.Repository.KeyVariables;

internal sealed class KeyVariableCommandRepositoryPortAdapter : AbstractEntityCommandRepositoryPortAdapter<KeyVariable, KeyVariableId, Guid>, IKeyVariableCommandRepositoryPort
{
    public KeyVariableCommandRepositoryPortAdapter(DefaultDbContext dbContext) : base(dbContext)
    {
    }
}