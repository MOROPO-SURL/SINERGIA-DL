using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Command.Interfaces;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.TerritoryPotentials.CQRS.Command.Update;

public record TerritoryPotentialUpdateCommand(Guid Id, string Title, string? Description = null) : IUpdateCommand<Guid, DTOs.TerritoryPotentialDetailDto>;