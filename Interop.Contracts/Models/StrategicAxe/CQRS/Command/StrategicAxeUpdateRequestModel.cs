namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.StrategicAxe.CQRS.Command;

public record StrategicAxeUpdateRequestModel(int Id, bool IsEnabled, string Name, Guid? CoordinatorId, string? Description = null);