namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.TerritoryPotential.CQRS.Command;

public record TerritoryPotentialUpdateRequestModel(Guid Id, string Title, string? Description = null);