namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.StrategicProject.CQRS.Command;

public record StrategicProjectCreateRequestModel(string Name, Guid KindId, Guid ProgramId, int Priority, bool IsEnabled, string? Description = null);