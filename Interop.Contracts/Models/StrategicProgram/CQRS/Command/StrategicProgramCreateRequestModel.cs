namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.StrategicProject.CQRS.Command;

public record StrategicProgramCreateRequestModel(bool IsEnabled, string Name, int Priority, string? Description = null);