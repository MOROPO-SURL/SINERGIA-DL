using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.TerritoryPotentials.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TerritoryPotentialAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TerritoryPotentialAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Persistence.EF;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Persistence.EF.Repositories.Abstractions;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Ports.Adapters.Repository.TerritoryPotentials;

internal sealed class TerritoryPotentialCommandRepositoryPortAdapter : AbstractEntityCommandRepositoryPortAdapter<TerritoryPotential, TerritoryPotentialId, Guid>, ITerritoryPotentialCommandRepositoryPort
{
    public TerritoryPotentialCommandRepositoryPortAdapter(DefaultDbContext dbContext) : base(dbContext)
    {
    }
}