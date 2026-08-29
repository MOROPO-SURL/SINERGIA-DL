namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.PDLModality.DTOs;

public record PDLModalityDetailDtoModel(Guid Id, string Name, bool IsEnabled, int Priority, string? Description = null);