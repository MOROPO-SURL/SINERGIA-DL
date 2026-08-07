namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Objectives.CQRS.Command.Create.Addon;

public record ObjectiveActionIndicatorMilestoneCreateCommand(Guid Id, DateOnly At, float Amount, string? Description = null);
