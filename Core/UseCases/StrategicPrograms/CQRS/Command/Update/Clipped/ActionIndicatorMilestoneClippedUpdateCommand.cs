namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicPrograms.CQRS.Command.Update.Clipped;

public record ActionIndicatorMilestoneClippedUpdateCommand(Guid Id, DateOnly At, float Amount, string? Description = null);