namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.StrategicProjectIdea.CQRS.Command;

public record StrategicProjectIdeaCreateRequestModel(string Title, Guid ProgramId, int Priority, bool IsEnabled, string? Description = null);