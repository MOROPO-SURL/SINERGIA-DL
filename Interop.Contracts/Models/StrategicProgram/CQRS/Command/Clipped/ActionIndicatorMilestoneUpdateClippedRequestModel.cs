namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.StrategicProgram.CQRS.Command.Clipped;

public record ActionIndicatorMilestoneUpdateClippedRequestModel(Guid Id, DateOnly At, float Amount, string? Description = null);