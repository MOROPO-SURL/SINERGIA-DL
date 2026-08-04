namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.PDLModality.CQRS.Command;

public record PDLModalityUpdateRequestModel(Guid Id, string Name, bool IsEnabled, int Priority, string? Description = null);