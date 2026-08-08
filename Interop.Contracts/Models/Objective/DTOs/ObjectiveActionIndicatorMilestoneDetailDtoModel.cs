namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Objective.DTOs;

public record ObjectiveActionIndicatorMilestoneDetailDtoModel(Guid Id, DateOnly At, float Amount, string? Description = null);
