namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.StrategicProgram.CQRS.Command.Clipped;

public record ImpactUpdateClippedRequestModel(Guid Id, string Name, int Priority, string? Description = null);