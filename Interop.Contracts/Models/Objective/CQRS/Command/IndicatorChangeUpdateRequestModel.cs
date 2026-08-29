namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.Objective.CQRS.Command;

public sealed record IndicatorChangeUpdateRequestModel(DateTime Id, Guid ObjectiveId, Guid ActionId, Guid IndicatorId, float Amount, string? Context = null);