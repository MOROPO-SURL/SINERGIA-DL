namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.StrategicProjectKind.CQRS.Command;

public record StrategicProjectKindUpdateRequestModel(Guid Id, string Name, string? Description = null);