namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.StrategicProgram.CQRS.Command;

public sealed record IndicatorChangeUpdateRequestModel(DateTime Id, Guid ProgramId, Guid ActionId, Guid IndicatorId, float Amount, string? Context = null);