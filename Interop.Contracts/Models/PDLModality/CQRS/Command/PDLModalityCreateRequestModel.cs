namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.PDLModality.CQRS.Command;

public record PDLModalityCreateRequestModel(string Name, bool IsEnabled, int Priority, string? Description = null);