namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.StrategicProject.CQRS.Command.Clipped;

public record IndicatorMilestoneCreateClippedRequestModel(Guid Id, DateOnly At, float Amount, string? Description = null);
