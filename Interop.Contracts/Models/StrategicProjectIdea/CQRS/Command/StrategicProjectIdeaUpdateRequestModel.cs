namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.StrategicProjectIdea.CQRS.Command;

public record StrategicProjectIdeaUpdateRequestModel(Guid Id, string Title, Guid ProgramId, int Priority, bool IsEnabled, string? Description = null);