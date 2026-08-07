namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.StrategicProject.CQRS.Command.Clipped;

public record IndicatorMilestoneUpdateClippedRequestModel(Guid Id, DateOnly At, float Amount, string? Description = null);
