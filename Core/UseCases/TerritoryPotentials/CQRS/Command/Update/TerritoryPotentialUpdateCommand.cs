using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Command.Interfaces;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.TerritoryPotentials.CQRS.Command.Update;

public record TerritoryPotentialUpdateCommand(Guid Id, string Title, string? Description = null) : IUpdateCommand<Guid, DTOs.TerritoryPotentialDetailDto>;