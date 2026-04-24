namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.StrategicProject.CQRS.Command;

public record StrategicLineUpdateRequestModel(bool IsEnabled, string Name, int Priority, string? Description = null);