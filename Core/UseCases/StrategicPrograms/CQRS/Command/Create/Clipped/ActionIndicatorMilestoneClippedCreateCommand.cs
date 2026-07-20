namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicPrograms.CQRS.Command.Create.Clipped;

public record ActionIndicatorMilestoneClippedCreateCommand(Guid Id, DateOnly At, float Amount, string? Description = null);