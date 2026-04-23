using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.KeyVariables.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.KeyVariableAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.KeyVariableAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Persistence.EF;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Persistence.EF.Repositories.Abstractions;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Ports.Adapters.Repository.KeyVariables;

internal sealed class KeyVariableCommandRepositoryPortAdapter : AbstractEntityCommandRepositoryPortAdapter<KeyVariable, KeyVariableId, Guid>, IKeyVariableCommandRepositoryPort
{
    public KeyVariableCommandRepositoryPortAdapter(DefaultDbContext dbContext) : base(dbContext)
    {
    }
}