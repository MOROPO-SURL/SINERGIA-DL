using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Command.Interfaces;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.TerritoryPotentials.CQRS.Command.Archive;

public record TerritoryPotentialArchiveCommand(Guid Id) : IArchiveCommand<Guid>;