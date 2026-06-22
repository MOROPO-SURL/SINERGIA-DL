namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.StrategicProject.CQRS.Command;

public record StrategicProjectUpdateRequestModel(Guid Id, string Name, Guid KindId, Guid ProgramId, int Priority, bool IsEnabled, string Objective, string? Description = null);