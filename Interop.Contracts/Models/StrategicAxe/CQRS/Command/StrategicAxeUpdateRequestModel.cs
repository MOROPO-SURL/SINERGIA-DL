namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.StrategicAxe.CQRS.Command;

public record StrategicAxeUpdateRequestModel(bool IsEnabled, string Name, string? Description = null);

