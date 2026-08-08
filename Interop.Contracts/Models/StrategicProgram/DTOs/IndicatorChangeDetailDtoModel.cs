namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.StrategicProgram.DTOs;

public sealed record IndicatorChangeDetailDtoModel(DateTime Id, Guid ProgramId, Guid ActionId, Guid IndicatorId, float Amount, string? Context = null);