namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.StrategicProject.CQRS.Command;

public sealed record IndicatorChangeCreateRequestModel(DateTime Id, Guid ProjectId, Guid IndicatorId, float Amount, string? Context = null);