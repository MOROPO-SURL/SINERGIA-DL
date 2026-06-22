namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.StrategicLine.CQRS.Command;

public record StrategicLineCreateRequestModel(int Index, bool IsEnabled, string Name, Guid CoordinatorId, string Objective, int? AxeId = null, string? Description = null);