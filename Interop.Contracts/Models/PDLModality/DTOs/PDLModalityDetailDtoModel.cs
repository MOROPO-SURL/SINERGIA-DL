namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.PDLModality.DTOs;

public record PDLModalityDetailDtoModel(Guid Id, string Name, bool IsEnabled, int Priority, string? Description = null);