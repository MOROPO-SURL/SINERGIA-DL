namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.StrategicProgram.CQRS.Command;

public sealed record IndicatorChangeCreateRequestModel(DateTime Id, Guid ProgramId, Guid ActionId, Guid IndicatorId, float Amount, string? Context = null);