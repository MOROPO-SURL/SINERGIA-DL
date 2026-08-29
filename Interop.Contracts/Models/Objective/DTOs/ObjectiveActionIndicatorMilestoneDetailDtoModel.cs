namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.Objective.DTOs;

public record ObjectiveActionIndicatorMilestoneDetailDtoModel(Guid Id, DateOnly At, float Amount, string? Description = null);
