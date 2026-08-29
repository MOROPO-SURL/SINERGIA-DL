namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.Objective.CQRS.Command;

public record ObjectiveActionIndicatorMilestoneUpdateRequestModel(Guid Id, DateOnly At, float Amount, string? Description = null);
