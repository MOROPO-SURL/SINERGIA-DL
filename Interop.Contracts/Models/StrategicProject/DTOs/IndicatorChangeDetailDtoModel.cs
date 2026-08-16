namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.StrategicProject.DTOs;

public sealed record IndicatorChangeDetailDtoModel(DateTime Id, Guid ProjectId, Guid IndicatorId, float Amount, string? Context = null);