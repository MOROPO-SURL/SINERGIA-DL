namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicProjects.CQRS.Command.Create.Clipped;

public record IndicatorMilestoneClippedCreateCommand(Guid Id, DateOnly At, float Amount, string? Description = null);
