namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.StrategicProject.CQRS.Command;

public sealed record IndicatorChangeCreateRequestModel(DateTime Id, Guid ProjectId, Guid IndicatorId, float Amount, string? Context = null);