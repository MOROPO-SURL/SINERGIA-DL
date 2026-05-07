namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.StrategicProject.CQRS.Command;

public record StrategicProgramUpdateRequestModel(Guid Id, string Name, int LineId, int AxeId, Guid CoordinatorId, int Priority, bool IsEnabled, string? Description = null);