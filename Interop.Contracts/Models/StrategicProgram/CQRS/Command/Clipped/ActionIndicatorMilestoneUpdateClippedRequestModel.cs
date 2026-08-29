namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.StrategicProgram.CQRS.Command.Clipped;

public record ActionIndicatorMilestoneUpdateClippedRequestModel(Guid Id, DateOnly At, float Amount, string? Description = null);