namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicProjects.CQRS.Command.Create.Clipped;

public record IndicatorMilestoneClippedCreateCommand(Guid Id, DateOnly At, float Amount, string? Description = null);
