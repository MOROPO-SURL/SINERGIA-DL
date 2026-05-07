namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.StrategicProject.CQRS.Command;

public record StrategicProgramCreateRequestModel(string Name, bool IsEnabled, int LineId, int AxeId, Guid CoordinatorId, int Priority, string? Description = null);