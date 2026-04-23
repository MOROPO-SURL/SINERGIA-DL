using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Command.Interfaces;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.TerritoryPotentials.CQRS.Command.Unarchive;

public record TerritoryPotentialUnarchiveCommand(Guid Id) : IUnarchiveCommand<Guid>;