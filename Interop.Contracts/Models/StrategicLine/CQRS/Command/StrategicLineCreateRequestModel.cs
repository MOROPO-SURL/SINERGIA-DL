namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.StrategicLine.CQRS.Command;

public record StrategicLineCreateRequestModel(int Id, int AxeId, bool IsEnabled, string Name, Guid CoordinatorId, string? Description = null);