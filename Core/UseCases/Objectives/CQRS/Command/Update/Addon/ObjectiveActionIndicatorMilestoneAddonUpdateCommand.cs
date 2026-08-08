namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Objectives.CQRS.Command.Update.Addon;

public record ObjectiveActionIndicatorMilestoneAddonUpdateCommand(Guid Id, DateOnly At, float Amount, string? Description = null);
