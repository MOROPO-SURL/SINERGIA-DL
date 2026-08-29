namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Objectives.CQRS.Command.Update.Addon;

public record ObjectiveActionIndicatorMilestoneAddonUpdateCommand(Guid Id, DateOnly At, float Amount, string? Description = null);
