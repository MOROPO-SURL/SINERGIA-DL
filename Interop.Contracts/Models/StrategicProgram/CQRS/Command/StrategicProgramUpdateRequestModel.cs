namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.StrategicProject.CQRS.Command;

public record StrategicProgramUpdateRequestModel(Guid Id, string Name, Guid LineId, Guid CoordinatorId, string Objective, int Priority, bool IsEnabled, string? Description = null);