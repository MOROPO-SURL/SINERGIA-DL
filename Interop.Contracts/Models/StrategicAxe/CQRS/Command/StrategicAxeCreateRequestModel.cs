namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.StrategicAxe.CQRS.Command;

public record StrategicAxeCreateRequestModel(int Id, bool IsEnabled, string Name, Guid? CoordinatorId, string? Description = null);