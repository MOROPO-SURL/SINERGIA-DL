using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Command.Interfaces;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.TerritoryPotentials.CQRS.Command.Unarchive;

public record TerritoryPotentialUnarchiveCommand(Guid Id) : IUnarchiveCommand<Guid>;