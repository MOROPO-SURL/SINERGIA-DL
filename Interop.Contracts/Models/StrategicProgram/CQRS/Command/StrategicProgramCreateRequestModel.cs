namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.StrategicProject.CQRS.Command;

public record StrategicProgramCreateRequestModel(string Name, bool IsEnabled, Guid LineId, Guid CoordinatorId, string Objective, int Priority, string? Description = null);