namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicProjects.CQRS.Command.Update.Clipped;

public record IndicatorMilestoneClippedUpdateCommand(Guid Id, DateOnly At, float Amount, string? Description = null);
