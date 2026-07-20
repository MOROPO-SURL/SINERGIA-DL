namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.StrategicProgram.CQRS.Command.Clipped;

public record ImpactCreateClippedRequestModel(Guid Id, string Name, int Priority, string? Description = null);