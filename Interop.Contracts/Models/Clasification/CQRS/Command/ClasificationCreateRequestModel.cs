namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.Clasification.CQRS.Command;

public record ClasificationCreateRequestModel(string Name, int Priority, string? Description = null);