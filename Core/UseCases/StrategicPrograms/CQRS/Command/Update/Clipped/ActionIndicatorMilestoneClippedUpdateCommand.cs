namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicPrograms.CQRS.Command.Update.Clipped;

public record ActionIndicatorMilestoneClippedUpdateCommand(Guid Id, DateOnly At, float Amount, string? Description = null);