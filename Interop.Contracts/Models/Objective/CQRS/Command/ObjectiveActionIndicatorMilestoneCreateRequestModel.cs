namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Objective.CQRS.Command;

public record ObjectiveActionIndicatorMilestoneCreateRequestModel(Guid Id, DateOnly At, float Amount, string? Description = null);
