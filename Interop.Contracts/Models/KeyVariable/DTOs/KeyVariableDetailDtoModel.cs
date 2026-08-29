namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.KeyVariable.DTOs;

public record KeyVariableDetailDtoModel(Guid Id, string Name, int Priority, string? Alias = null, string? Description = null);