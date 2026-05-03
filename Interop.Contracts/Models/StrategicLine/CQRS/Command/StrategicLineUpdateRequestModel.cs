namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.StrategicLine.CQRS.Command;

public record StrategicLineUpdateRequestModel(int Id, int AxeId, bool IsEnabled, string Name, string? Description = null);