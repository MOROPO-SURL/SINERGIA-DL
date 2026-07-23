namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicProjects.CQRS.Command.Update.Clipped;

public record IndicatorMilestoneClippedUpdateCommand(Guid Id, DateOnly At, float Amount, string? Description = null);
