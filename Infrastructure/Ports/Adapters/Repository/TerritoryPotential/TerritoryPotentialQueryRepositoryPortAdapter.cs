using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.TerritoryPotentials.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TerritoryPotentialAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TerritoryPotentialAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Persistence.EF;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Persistence.EF.Repositories.Abstractions;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Ports.Adapters.Repository.TerritoryPotentials;

internal sealed class TerritoryPotentialQueryRepositoryPortAdapter : AbstractEntityQueryRepositoryPortAdapter<TerritoryPotential, TerritoryPotentialId, Guid>, ITerritoryPotentialQueryRepositoryPort
{
    public TerritoryPotentialQueryRepositoryPortAdapter(DefaultDbContext dbContext) : base(dbContext)
    {
    }
}