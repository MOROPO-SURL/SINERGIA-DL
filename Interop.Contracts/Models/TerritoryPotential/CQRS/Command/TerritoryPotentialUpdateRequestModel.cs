namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.TerritoryPotential.CQRS.Command;

public record TerritoryPotentialUpdateRequestModel(Guid Id, string Title, string? Description = null);