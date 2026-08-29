using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TerritoryPotentialAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TerritoryPotentialAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.TerritoryPotentials.Ports.Repository;

public interface ITerritoryPotentialCommandRepositoryPort : IEntityCommandRepositoryPort<TerritoryPotential, TerritoryPotentialId, Guid>
{
}