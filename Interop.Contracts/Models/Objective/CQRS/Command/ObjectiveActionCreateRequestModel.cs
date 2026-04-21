namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Objective.CQRS.Command;

public record ObjectiveActionCreateRequestModel(Guid Id, int Index, string Title, string? Description = null);