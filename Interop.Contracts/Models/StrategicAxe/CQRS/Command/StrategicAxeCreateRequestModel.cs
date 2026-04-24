namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.StrategicAxe.CQRS.Command;

public record StrategicAxeCreateRequestModel(bool IsEnabled, string Name, string? Description = null);

