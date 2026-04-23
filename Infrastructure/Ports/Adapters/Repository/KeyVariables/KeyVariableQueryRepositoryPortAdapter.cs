using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.KeyVariables.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.KeyVariableAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.KeyVariableAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Persistence.EF;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Persistence.EF.Repositories.Abstractions;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Ports.Adapters.Repository.KeyVariables;

internal sealed class KeyVariableQueryRepositoryPortAdapter : AbstractEntityQueryRepositoryPortAdapter<KeyVariable, KeyVariableId, Guid>, IKeyVariableQueryRepositoryPort
{
    public KeyVariableQueryRepositoryPortAdapter(DefaultDbContext dbContext) : base(dbContext)
    {
    }
}