namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.StrategicProgram.CQRS.Command.Clipped;

public record ImpactUpdateClippedRequestModel(Guid Id, string Name, int Priority, string? Description = null);