using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.TerritoryPotentials.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TerritoryPotentialAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TerritoryPotentialAggregate.Values;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Persistence.EF;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Persistence.EF.Repositories.Abstractions;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Ports.Adapters.Repository.TerritoryPotentials;

internal sealed class TerritoryPotentialQueryRepositoryPortAdapter : AbstractEntityQueryRepositoryPortAdapter<TerritoryPotential, TerritoryPotentialId, Guid>, ITerritoryPotentialQueryRepositoryPort
{
    public TerritoryPotentialQueryRepositoryPortAdapter(DefaultDbContext dbContext) : base(dbContext)
    {
    }
}